DROP TABLE [Moaddel]
SELECT StudentID,Grade Payeh,AVG PayehaMoadel INTO [Moaddel] FROM (SELECT * FROM [AmarPartDB_95-03-07].dbo.TBL_Arziabi  WHERE AVG IS NOT NULL AND AVG>0)b 
