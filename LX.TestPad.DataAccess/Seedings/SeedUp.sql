﻿SET IDENTITY_INSERT [dbo].[Tests] ON
INSERT INTO [dbo].[Tests] ([Id], [Name], [Description], [TestDuration]) VALUES ( 1, N'Java', N'a high-level, class-based, object-oriented programming language that is designed to have as few.', 30)
SET IDENTITY_INSERT [dbo].[Tests] OFF

SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES ( 1, N'Given Interface: Foo extends Behaviour . Can Foo extend additional interfaces?' )
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (2, N'Select keywords in Java')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (3, N'What would display from the following statements? int[]nums; {1,2,3,4,5,6}; System.out.println(( nums[1] + nums[3])); ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (4, N'Which SQL keywords is used to sort the result-set ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (5, N'Which of the dollowing store elements as key-value pairs ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (6, N'Which SQL statement is used to extract data from a database? ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (7, N'What is a method signature ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (8, N'Given the declaration : int[] ar ={1,2,3,4,5}; What is the value of ar[3]? ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (9, N'A class is... ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (10, N'What will be the out for the following programm int a=10; System.out.println(+aa=a++); System.out.printl(a++=a++); ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (11, N'If none of the private/protected/public is specified for a member, that member... ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (12, N'The last value in an array callsed ar can be found at index... ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (13, N'Which one of the following statement is correct? ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (14, N'What will be the out for the following program: ')
INSERT INTO [dbo].[Questions] ([Id], [Text]) VALUES (15, N'Select statements which are correct about HTTP methods ')
SET IDENTITY_INSERT [dbo].[Questions] OFF

SET IDENTITY_INSERT [dbo].[Answers] ON
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (1, 1, 'Depends on weather interface Behaviour extends another interface', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (2, 1, 'Yes, any number of interfaces', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (3, 1, 'No, because interface may extend only one interface', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (4, 1, 'Yes, only one interface', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (5, 2, 'null', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (6, 2, 'assert', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (7, 2, 'super', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (8, 2, 'abstract', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (9, 2, 'value', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (10, 3, '4', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (11, 3, '2+4', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (12, 3, '6', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (13, 3, '1+3', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (14, 4, 'ORDER', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (15, 4, 'ORDER BY', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (16, 4, 'SORT BY', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (17, 4, 'SORT', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (18, 5, 'List', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (19, 5, 'Map', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (20, 5, 'array', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (21, 5, 'Set', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (22, 6, 'EXTRACT', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (23, 6, 'GET', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (24, 6, 'SELECT', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (25, 6, 'READ', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (26, 7, 'The name of the method and parameters (param names make sense)', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (27, 7, 'The name of the method, parameters and return types', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (28, 7, 'The name of the method and parameters(types and order make sense)', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (29, 7, 'The name of the method, parameters, return types and thrown exceptions', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (30, 8, '2', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (31, 8, '3', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (32, 8, '4', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (33, 8, '5', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (34, 9, 'An abstract definition of an object', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (35, 9, 'An executable piece of code', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (36, 9, 'A varible', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (37, 9, 'An object', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (38, 10, 'false, false', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (39, 10, 'false, true', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (40, 10, 'true, true', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (41, 10, 'true, false', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (42, 11, 'Is only accessible from within the class', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (43, 11, 'Is accessible publicly', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (44, 11, 'Is accessible by the slass and its subclasses', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (45, 11, 'Is only accessible by other classes of the same package', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (46, 12, 'ar.length', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (47, 12, '1', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (48, 12, 'ar.length - 1', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (49, 12, '0', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (50, 13, 'The try block should be followed by either a catch block or a finally block', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (51, 13, 'The try block should be followed by a catch block', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (52, 13, 'The try block should be followed by a finally block', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (53, 13, 'The try block should be followed by both a catch block and a finally block', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (54, 14, 'Hello World printed 7 times', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (55, 14, 'compilation error', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (56, 14, 'Hello World printed 5 times', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (57, 14, 'Hello World printed 6 times', 0 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (58, 15, 'DELETE is used to delete a resource', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (59, 15, 'POST is used to insert', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (60, 15, 'PUT is used to update', 1 )
INSERT INTO [dbo].[Answers] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (61, 15, 'GET is used to get the resource', 1 )
SET IDENTITY_INSERT [dbo].[Answers] OFF

SET IDENTITY_INSERT [dbo].[TestQuestion] ON
INSERT INTO [dbo].[TestQuestion] ([Id], [TestId], [QuestionId], [Number]) VALUES ( 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[TestQuestion] OFF