ALTER TABLE [TBL_Name] ADD TahsilOstan NVARCHAR(200)
ALTER TABLE [TBL_Name] ADD Madreseh NVARCHAR(MAX)
GO
UPDATE c SET c.TahsilOstan=d.TahsilOstan,c.Madreseh=d.Madreseh FROM 
[TBL_Name] c
JOIN 
	(	SELECT StudentID,b.OstanStandard TahsilOstan,SchoolName Madreseh FROM [AmarPartDB_95-03-07].dbo.TBL_Student a
		INNER JOIN dbo.OstanTahsil_School b ON b.OstanName = a.OstanName
	)d
ON d.StudentID = c.StudentID
