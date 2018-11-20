USE [BangazonInc]
GO

ALTER TABLE [dbo].[EmployeeTraining] DROP CONSTRAINT [FK__EmployeeT__Progr__4E88ABD4]
GO

ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK__EmployeeT__Progr__4E88ABD4] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[TrainingProgram] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK__EmployeeT__Progr__4E88ABD4]
GO

ALTER TABLE [dbo].[EmployeeTraining] DROP CONSTRAINT [FK__EmployeeT__Emplo__4D94879B]
GO

ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK__EmployeeT__Emplo__4D94879B] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK__EmployeeT__Emplo__4D94879B]
GO

