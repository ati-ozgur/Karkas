-- random data for DECIMAL_TABLES
conn datatypes/datatypes

DECLARE
    i INTEGER := 1;
BEGIN
    WHILE i <= 1000
    LOOP
        INSERT INTO DECIMAL_TABLES (
            COLUMN_DECIMAL0,
            COLUMN_DECIMAL1,
            COLUMN_DECIMAL2,
            COLUMN_DECIMAL3,
            COLUMN_DECIMAL4,
            COLUMN_DECIMAL5,
            COLUMN_DECIMAL6,
            COLUMN_DECIMAL7
        ) VALUES (
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 38), POWER(10, 38))),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 37), POWER(10, 37)), 1),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 36), POWER(10, 36)), 2),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 35), POWER(10, 35)), 3),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 34), POWER(10, 34)), 4),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 33), POWER(10, 33)), 5),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 32), POWER(10, 32)), 6),
            TRUNC(DBMS_RANDOM.VALUE(-POWER(10, 31), POWER(10, 31)), 7)
        );
        i := i + 1;
    END LOOP;
    DBMS_OUTPUT.put_line('INSERT DECIMAL_TABLES FINISHED');
    COMMIT;
END;
/
