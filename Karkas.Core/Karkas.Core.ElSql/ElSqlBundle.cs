﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karkas.Core.ElSql.SqlFragments;

namespace Karkas.Core.ElSql
{

    public class ElSqlBundle
    {

        /**
         * The map of known elsql.
         */
        private Dictionary<String, NameSqlFragment> _map;
        /**
         * The config.
         */
        private ElSqlConfig _config;

        /**
         * Loads external SQL based for the specified type.
         * <p>
         * The type is used to identify the location and name of the ".elsql" file.
         * The loader will attempt to find and use two files, using the full name of
         * the type to query the class path for resources.
         * <p>
         * The first resource searched for is optional - the file will have the suffix
         * "-ConfigName.elsql", such as "com/foo/Bar-MySql.elsql".
         * The second resource searched for is mandatory - the file will just have the
         * ".elsql" suffix, such as "com/foo/Bar.elsql".
         * <p>
         * The config is designed to handle some, but not all, database differences.
         * Other differences should be handled by creating and using a database specific
         * override file (the first optional resource is the override file).
         * 
         * @param config  the config, not null
         * @param type  the type, not null
         * @return the bundle, not null
         * @throws ArgumentException if the input cannot be parsed
         */
        public static ElSqlBundle of(ElSqlConfig config, Type type)
        {
            if (config == null)
            {
                throw new ArgumentException("Config must not be null");
            }
            if (type == null)
            {
                throw new ArgumentException("Type must not be null");
            }
            // TODO decide how to implement this.
            throw new NotImplementedException();
            //ClassPathResource baseResource = new ClassPathResource(type.getSimpleName() + ".elsql", type);
            //ClassPathResource configResource = new ClassPathResource(type.getSimpleName() + "-" + config.getName() + ".elsql", type);
            //return parse(config, baseResource, configResource);
        }

        /**
         * Parses a bundle from a resource locating a file, specify the config.
         * <p>
         * This parses a list of resources. Named blocks in later resources override
         * blocks with the same name in earlier resources.
         * <p>
         * The config is designed to handle some, but not all, database differences.
         * Other differences are handled via the override resources passed in.
         * 
         * @param config  the config to use, not null
         * @param resources  the resources to load, not null
         * @return the external identifier, not null
         * @throws ArgumentException if the input cannot be parsed
         */
        public static ElSqlBundle parse(ElSqlConfig config, params Resource[] resources)
        {
            if (config == null)
            {
                throw new ArgumentException("Config must not be null");
            }
            if (resources == null)
            {
                throw new ArgumentException("Resources must not be null");
            }
            return parseResource(resources, config);
        }

        private static ElSqlBundle parseResource(Resource[] resources, ElSqlConfig config)
        {
            List<List<String>> files = new List<List<String>>();
            foreach (Resource resource in resources)
            {
                if (resource.exists())
                {
                    List<String> lines = loadResource(resource);
                    files.Add(lines);
                }
            }
            return parse(files, config);
        }

        // package scoped for testing
        static ElSqlBundle parse(List<String> lines)
        {
            List<List<String>> files = new List<List<String>>();
            files.Add(lines);
            return parse(files, ElSqlConfig.DEFAULT);
        }

        private static ElSqlBundle parse(List<List<String>> files, ElSqlConfig config)
        {
            Dictionary<String, NameSqlFragment> parsed = new Dictionary<String, NameSqlFragment>();
            foreach (List<String> lines in files)
            {
                ElSqlParser parser = new ElSqlParser(lines);
                var p = parser.parse();
                parsed = parsed.Concat(p).ToDictionary(e => e.Key, e => e.Value);
            }
            return new ElSqlBundle(parsed, config);
        }

        private static List<String> loadResource(Resource resource) {
            // TODO
            throw new NotImplementedException();
            //InputStream inputStream = null;
            //try {
            //  inputStream = resource.getInputStream();
            //  BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream, "UTF-8"));
            //  List<String> list = new List<String>();
            //  String line = reader.readLine();
            //  while (line != null) {
            //      list.Add(line);
            //      line = reader.readLine();
            //  }
            //  return list;
            //} catch (IOException ex) {
            //  throw new RuntimeException(ex);
            //} finally {
            //  try {
            //    if (in != null) {
            //      in.close();
            //    }
            //  } catch (IOException ignored) {
            //  }
            //}
  }

        /**
         * Creates an instance..
         * 
         * @param map  the map of names, not null
         * @param config  the config to use, not null
         */
        private ElSqlBundle(Dictionary<String, NameSqlFragment> map, ElSqlConfig config)
        {
            if (map == null)
            {
                throw new ArgumentException("Fragment map must not be null");
            }
            if (config == null)
            {
                throw new ArgumentException("Config must not be null");
            }
            _map = map;
            _config = config;
        }

        //-------------------------------------------------------------------------
        /**
         * Gets the configuration object.
         * 
         * @return the config, not null
         */
        public ElSqlConfig getConfig()
        {
            return _config;
        }

        /**
         * Returns a copy of this bundle with a different configuration.
         * <p>
         * This does not reload the underlying resources.
         * 
         * @param config  the new config, not null
         * @return a bundle with the config updated, not null
         */
        public ElSqlBundle withConfig(ElSqlConfig config)
        {
            return new ElSqlBundle(_map, config);
        }

        //-------------------------------------------------------------------------
        /**
         * Finds SQL for a named fragment key, without specifying parameters.
         * <p>
         * This finds, processes and returns a named block from the bundle.
         * Note that if the SQL contains tags that depend on variables, like AND or LIKE,
         * then an error will be thrown.
         * 
         * @param name  the name, not null
         * @return the SQL, not null
         * @throws ArgumentException if there is no fragment with the specified name
         * @throws RuntimeException if a problem occurs
         */
        public String getSql(String name)
        {
            return getSql(name, new EmptySource());
        }

        /**
         * Finds SQL for a named fragment key.
         * <p>
         * This finds, processes and returns a named block from the bundle.
         * 
         * @param name  the name, not null
         * @param paramSource  the Spring SQL parameters, not null
         * @return the SQL, not null
         * @throws ArgumentException if there is no fragment with the specified name
         * @throws RuntimeException if a problem occurs
         */
        public String getSql(String name, SqlParameterSource paramSource)
        {
            NameSqlFragment fragment = getFragment(name);
            StringBuilder buf = new StringBuilder(1024);
            fragment.toSQL(buf, this, paramSource, -1);
            return buf.ToString();
        }

        //-------------------------------------------------------------------------
        /**
         * Gets a fragment by name.
         * 
         * @param name  the name, not null
         * @return the fragment, not null
         * @throws ArgumentException if there is no fragment with the specified name
         */
        internal NameSqlFragment getFragment(String name)
        {
            NameSqlFragment fragment = _map[name];
            if (fragment == null)
            {
                throw new ArgumentException("Unknown fragment name: " + name);
            }
            return fragment;
        }


    }
}