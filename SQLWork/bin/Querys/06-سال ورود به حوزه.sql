ALTER TABLE [TBL_Name] ADD SaleWorod INT
GO
UPDATE a SET a.SaleWorod=b.SaleWorod FROM [TBL_Name] a
JOIN (SELECT Min(a.MinInputScore)SaleWorod,StudentID FROM (SELECT * FROM [AmarPartDB_95-03-07].dbo.TBL_Arziabi WHERE MinInputScore IS NOT NULL AND  MinInputScore>0)a GROUP BY StudentID)b
ON b.StudentID = a.StudentID
