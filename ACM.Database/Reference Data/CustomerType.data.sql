DELETE FROM CustomerType

SET IDENTITY_INSERT [dbo].[CustomerType] ON
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName], [IsSystem]) VALUES (1, N'Corporation',1)
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName], [IsSystem]) VALUES (2, N'Individual',1)
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName], [IsSystem]) VALUES (3, N'Educator',1)
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName], [IsSystem]) VALUES (4, N'Government',1)
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
