SET IDENTITY_INSERT [CustomerType] ON
GO

-- Reference Data for CustomerType 
MERGE INTO CustomerType AS Target 
USING (VALUES 
  (1, N'Corporation', 1), 
  (2, N'Individual', 1), 
  (3, N'Educator', 1)
) 
AS Source (CustomerTypeId, [Description], IsSystem) 
ON Target.CustomerTypeId = Source.CustomerTypeId

-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET [Description] = Source.[Description],
                     IsSystem = Source.IsSystem

-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (CustomerTypeId,
		[Description], 
        IsSystem) 
VALUES (Source.CustomerTypeId,
		Source.[Description], 
        Source.IsSystem);

GO
SET IDENTITY_INSERT [CustomerType] OFF
GO
