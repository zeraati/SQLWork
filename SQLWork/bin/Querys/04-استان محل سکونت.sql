ALTER TABLE [TBL_Name] ADD SokonatOstan NVARCHAR(200)
GO
UPDATE d SET d.SokonatOstan=e.SokonatOstan FROM [TBL_Name] d
JOIN 
	(	SELECT a.StudentID,c.Ostan SokonatOstan FROM dbo.STMK_Hoviat a
		LEFT JOIN [AmarPartDB_95-03-07].dbo.TBL_MKsarparast b ON a.MKID=b.CodeMarkazKhadamat
		LEFT JOIN dbo.MKOstan c ON b.Shobe=c.Shobe
	)e
ON e.StudentID = d.StudentID
