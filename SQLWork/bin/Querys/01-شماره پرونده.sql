SELECT c.StudentID,d.Life INTO [TBLNAME] FROM [AmarPartDB_95-03-07].dbo.TBL_Student c
LEFT JOIN
(		SELECT a.*,Life=N'مرحوم' FROM dbo.STMK_Hoviat a
		JOIN [AmarPartDB_95-03-07].dbo.TBL_MKafrad_sabegh b
		ON b.[کد مرکز] = a.MKID WHERE b.[وضعیت حیات]=N'مرحوم'
)d ON c.StudentID=d.StudentID WHERE d.Life IS NULL