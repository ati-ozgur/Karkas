conn chinook/chinook

ALTER TABLE "Album" MODIFY ("AlbumId" GENERATED ALWAYS AS IDENTITY (START WITH 348));

ALTER TABLE "Artist" MODIFY ("ArtistId" GENERATED ALWAYS AS IDENTITY (START WITH 276));

ALTER TABLE "Customer" MODIFY ("CustomerId" GENERATED ALWAYS AS IDENTITY (START WITH 60));

ALTER TABLE "Employee" MODIFY ("EmployeeId" GENERATED ALWAYS AS IDENTITY (START WITH 9));

ALTER TABLE "Genre" MODIFY ("GenreId" GENERATED ALWAYS AS IDENTITY (START WITH 26));

ALTER TABLE "Invoice" MODIFY ("InvoiceId" GENERATED ALWAYS AS IDENTITY (START WITH 413));

ALTER TABLE "InvoiceLine" MODIFY ("InvoiceLineId" GENERATED ALWAYS AS IDENTITY (START WITH 2241));

ALTER TABLE "MediaType" MODIFY ("MediaTypeId" GENERATED ALWAYS AS IDENTITY (START WITH 6));

ALTER TABLE "Playlist" MODIFY ("PlaylistId" GENERATED ALWAYS AS IDENTITY (START WITH 19));

ALTER TABLE "Track" MODIFY ("TrackId" GENERATED ALWAYS AS IDENTITY (START WITH 3504));




commit;
exit;