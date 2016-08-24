ALTER TABLE [TBL_Name] ADD SodorKeshvar NVARCHAR(50)
ALTER TABLE [TBL_Name] ADD SodorOstan NVARCHAR(50)
GO
UPDATE c SET c.SodorKeshvar=d.SodorKeshvar,c.SodorOstan=d.SodorOstan FROM [TBL_Name] c
JOIN 
	(	SELECT a.StudentID,b.OstanStandard SodorOstan,b.Keshvar SodorKeshvar FROM 
			(		SELECT StudentID,CASE WHEN CHARINDEX(N':',Sodor)>0THEN REPLACE(LEFT(Sodor,CHARINDEX(N':',Sodor)),N':','')ELSE Sodor END AS Sodor
					FROM [AmarPartDB_95-03-07].dbo.TBL_Student WHERE Sodor IS NOT NULL
			)a
		LEFT JOIN dbo.SodorOstan b ON b.Ostan = a.Sodor
	)d
ON d.StudentID = c.StudentID