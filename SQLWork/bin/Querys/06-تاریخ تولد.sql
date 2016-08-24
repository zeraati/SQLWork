ALTER TABLE [TBL_Name] ADD TarikhTavalod INT
GO
UPDATE a SET a.TarikhTavalod=b.TarikhTavalod FROM [TBL_Name] a
JOIN(SELECT StudentID,CONVERT(INT,LEFT(dbo.UDF_Gregorian_To_Persian(BirthDate),4))TarikhTavalod FROM [AmarPartDB_95-03-07].dbo.TBL_Student)b
ON b.StudentID = a.StudentID
