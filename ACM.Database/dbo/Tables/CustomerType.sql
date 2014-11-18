CREATE TABLE [dbo].[CustomerType] (
    [CustomerTypeId] INT           NOT NULL IDENTITY,
    [TypeName]    NVARCHAR (50) NULL,
    [IsSystem] BIT NULL, 
    CONSTRAINT [PK_CustomerType] PRIMARY KEY ([CustomerTypeId]) 
);

