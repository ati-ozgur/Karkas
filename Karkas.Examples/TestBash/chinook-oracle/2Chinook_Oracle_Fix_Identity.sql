conn chinook/chinook

ALTER TABLE "Album" MODIFY ("AlbumId" GENERATED ALWAYS AS IDENTITY (START WITH 348));

commit;
exit;