– Reference Data for the CustomerType table 
SET IDENTITY_INSERT [CustomerType] ON 
  
MERGE INTO [CustomerType] AS Target 
USING (VALUES 
            (1, N’Corporation’, 2), 
            (2, N’Individual’, 1), 
            (3, N’Educator’, 3), 
            (4, N’Government’, 4)) 
AS Source ([CustomerTypeId], 
            [TypeName], 
            [DisplayOrder]) 
ON (Target.[CustomerTypeId] = Source.[CustomerTypeId])

WHEN MATCHED AND 
            (Target.[TypeName] <> Source.[TypeName]) THEN 
UPDATE SET 
            [TypeName] = Source.[TypeName], 
            [DisplayOrder] = Source.[DisplayOrder]

WHEN NOT MATCHED BY TARGET THEN 
INSERT([CustomerTypeId], 
            [TypeName], 
            [DisplayOrder]) 
VALUES(Source.[CustomerTypeId], 
        Source.[TypeName], 
        Source.[DisplayOrder])

– delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE; 
  
GO 
  
SET IDENTITY_INSERT [CustomerType] OFF 
GO

