USE [NewDataBS]
GO
/****** Object:  Table [dbo].[tbl_Employees]    Script Date: 4/14/2023 3:39:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Gender] [varchar](15) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[Mobile] [varchar](15) NOT NULL,
	[Address1] [varchar](100) NOT NULL,
	[Address2] [varchar](100) NOT NULL,
	[Pincode] [varchar](20) NOT NULL,
	[Is_Active] [tinyint] NULL,
	[Emp_Code]  AS ('INF'+right('0000'+CONVERT([varchar](5),[Id]),(5))) PERSISTED
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Mobile] [varchar](15) NULL,
	[IsActive] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Employees] ON 

INSERT [dbo].[tbl_Employees] ([Id], [FirstName], [LastName], [Gender], [Email], [Password], [Mobile], [Address1], [Address2], [Pincode], [Is_Active]) VALUES (7, N'Adarsh', N'Verma', N'Male', N'adarsh98@gmail.com', N'Adarsh23', N'6342697609', N'Noida', N'Uttar Pradesh', N'200543', 0)
INSERT [dbo].[tbl_Employees] ([Id], [FirstName], [LastName], [Gender], [Email], [Password], [Mobile], [Address1], [Address2], [Pincode], [Is_Active]) VALUES (8, N'Jatin', N'Arora', N'Male', N'arora08@gmail.com', N'Arotra23', N'8842697609', N'Noida', N'Uttar Pradesh', N'200543', 0)
INSERT [dbo].[tbl_Employees] ([Id], [FirstName], [LastName], [Gender], [Email], [Password], [Mobile], [Address1], [Address2], [Pincode], [Is_Active]) VALUES (9, N'Lallan', N'Prasad', N'Male', N'lallan08@gmail.com', N'lallana23', N'8842554409', N'Ghazipur', N'Uttar Pradesh', N'211543', 1)
INSERT [dbo].[tbl_Employees] ([Id], [FirstName], [LastName], [Gender], [Email], [Password], [Mobile], [Address1], [Address2], [Pincode], [Is_Active]) VALUES (1003, N'Amar', N'Singh', N'Male', N'amar123@gmail.com', N'Amar@123', N'7216543219', N'Delhi', N'Delhi', N'537722', 0)
INSERT [dbo].[tbl_Employees] ([Id], [FirstName], [LastName], [Gender], [Email], [Password], [Mobile], [Address1], [Address2], [Pincode], [Is_Active]) VALUES (1004, N'Satyam', N'Prajapati', N'Male', N'satyam12@gmail.com', N'07076', N'8842550899', N'Azamgarh', N'Uttar Pradesh', N'271503', 1)
SET IDENTITY_INSERT [dbo].[tbl_Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[tblAdmin] ON 

INSERT [dbo].[tblAdmin] ([Id], [FirstName], [LastName], [Email], [Password], [Mobile], [IsActive]) VALUES (1, N'Admin', N'1', N'admin123@gmail.com', N'12345', N'8463727272', 1)
INSERT [dbo].[tblAdmin] ([Id], [FirstName], [LastName], [Email], [Password], [Mobile], [IsActive]) VALUES (2, N'Pawan', N'Kumar', N'pawan123@gmail.com', N'Pawan@123', N'8463728972', 0)
INSERT [dbo].[tblAdmin] ([Id], [FirstName], [LastName], [Email], [Password], [Mobile], [IsActive]) VALUES (3, N'Ashish', N'Agrahari', N'ashish420@gmail.com', N'Ashish@420', N'9463007272', 1)
INSERT [dbo].[tblAdmin] ([Id], [FirstName], [LastName], [Email], [Password], [Mobile], [IsActive]) VALUES (4, N'Ritik', N'Prajapati', N'ritik123@gmail.com', N'1234', N'8463700896', 0)
SET IDENTITY_INSERT [dbo].[tblAdmin] OFF
GO
/****** Object:  StoredProcedure [dbo].[login_user]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[login_user]
@Email varchar(100),
@Password varchar(100)
as 
begin
if(EXISTS(select Email from tblAdmin where email=@Email and Password=@Password))
begin
select 1 isauthenticated
end
else
begin
select 0 isauthenticated
end 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_Employees]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_delete_Employees]
@Id as int

as
  begin
       delete from tbl_Employees where Id=@Id
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_get_Employees]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_get_Employees]
@id int=null
as
begin
select Id,FirstName,LastName,Gender,Email,Password,Mobile,Address1,Address2,Pincode,Is_Active,Emp_Code from tbl_Employees where id=ISNULL(@Id,Id)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_Employees]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_insert_Employees]
@FirstName varchar(100),
@LastName varchar(100),
@Gender varchar(15),
@Email varchar(50),
@Password varchar(50),
@Mobile Varchar(20),
@Address1 varchar(100),
@Address2 varchar(100),
@Pincode varchar(20),
@Is_Active tinyint

as
  begin
       declare @c int
	   select @c=count(*) from tbl_Employees where Email=@Email
	   if(@c>0)
	          begin 
			       select 0 as created
             end
        else
		    begin
			      insert into tbl_Employees(FirstName,LastName,Gender,Email,Password,Mobile,Address1,Address2,Pincode,Is_Active) values
				(@FirstName,@LastName,@Gender,@Email,@Password,@Mobile,@Address1,@Address2,@Pincode,@Is_Active)


                   select 1 as  created
            end
       end
GO
/****** Object:  StoredProcedure [dbo].[sp_login_Employees]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_login_Employees] 
@Email varchar(100),  
@Password varchar(100)  
as  
begin  
if(Exists(select 1 from tbl_Employees where Email=@Email and Password=@Password))  
begin   
select 1 as exist  
end   
else  
begin   
select 0 as exist  
end  
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_update_Employees]    Script Date: 4/14/2023 3:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_update_Employees]
@Id int,
@FirstName varchar(100),
@LastName varchar(100),
@Gender varchar(15),
@Email varchar(50),
@Password varchar(50),
@Mobile Varchar(20),
@Address1 varchar(100),
@Address2 varchar(100),
@Pincode varchar(20),
@Is_Active tinyint

as
   begin
       update tbl_Employees set FirstName=isnull(@FirstName,FirstName),LastName=ISNULL(@LastName,LastName),Gender=isnull(@Gender,Gender),
	   Email=ISNULL(@Email,Email),Password=isnull(@Password,Password),Mobile=ISNULL(@Mobile,Mobile),Address1=isnull(@Address1,Address1),Address2=isnull(@Address2,Address2),
	   Pincode=isnull(@Pincode,Pincode),Is_Active=ISNULL(@Is_Active,Is_Active)
	   where Id=@Id
	    
      select 1 as updated
   end
GO
