SET IDENTITY_INSERT [dbo].[Tests] ON
INSERT INTO [dbo].[Tests] ([Id], [Name], [Description], [TestDuration]) VALUES (2, N'C#', N' C# test', 300000)
SET IDENTITY_INSERT [dbo].[Tests] OFF

SET IDENTITY_INSERT [dbo].[TestQuestion] ON
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (2, 1, 2, 2)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (3, 1, 3, 3)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (4, 1, 4, 4)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (5, 1, 5, 5)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (6, 1, 6, 6)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (7, 1, 7, 7)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (8, 1, 8, 8)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (9, 1, 9, 9)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (10, 1, 10, 10)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (11, 1, 11, 11)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (12, 1, 12, 12)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (13, 1, 13, 13)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (14, 1, 14, 14)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (15, 1, 15, 15)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (16, 2, 14, 1)
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES (17, 2, 15, 2)
SET IDENTITY_INSERT [dbo].[TestQuestion] OFF

