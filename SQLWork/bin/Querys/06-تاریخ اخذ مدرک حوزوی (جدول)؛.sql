DROP TABLE [TBL_Name]
SELECT MIN(REPLACE(Date,'13',''))SathHozaviTarikh,StudentID,LevelID SathHozavi INTO [TBL_Name] FROM [AmarPartDB_95-03-07].dbo.TBL_Level GROUP BY StudentID,LevelID
