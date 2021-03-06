USE [ERIMS_Sonic]
GO
/****** Object:  StoredProcedure [dbo].[Chart_FacilityInspectionByLocation]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Chart_FacilityInspectionByLocation 2009,'A'
CREATE PROCEDURE [dbo].[Chart_FacilityInspectionByLocation]
(
	@Year int,
	@Region nvarchar(200),  
	@PK_Security_ID numeric(20,0)  
)
AS 

DECLARE @Date DATETIME,@Curr_Date DATETIME;

SET @Curr_Date = GETDATE()

-- If Passed Date Year is not Current Year then Use Last date of Passed 
IF(@Year != YEAR(@Curr_Date))
	SET @Date = '31-Dec-' + CAST(@Year AS varchar)
ELSE
	SET @Date = @Curr_Date;

PRINT @Date

SELECT
	A.[DBA],
	CASE WHEN A.[Repeat_Deficiencies] > 3 OR B.[Average_Days_Open] > 28 THEN
		1
	ELSE
		CASE WHEN A.[Repeat_Deficiencies] = 3 OR (B.[Average_Days_Open] > 21 AND B.[Average_Days_Open] <=28) THEN
			2
		ELSE
			CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 14 AND B.[Average_Days_Open] <= 21) THEN
				3
			ELSE
				CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 7 AND B.[Average_Days_Open] <= 14) THEN
					4
				ELSE
					5
				END
			END
		END
	END AS Score ,A.Sonic_Location_Code
FROM
	dbo.fn_RepeatDeficiencyByLocation(@Date,@Region,@PK_Security_ID) A,
	dbo.fn_AverageDaysOpenByLocation(@Date,@Curr_Date,@Region,@PK_Security_ID) B
WHERE
		A.[DBA] = B.[DBA] AND
		A.[Region] = B.[Region] AND A.[Region] = @Region

SELECT	
CAST(	AVG(CAST(CASE WHEN A.[Repeat_Deficiencies] > 3 OR B.[Average_Days_Open] > 28 THEN
		1
	ELSE
		CASE WHEN A.[Repeat_Deficiencies] = 3 OR (B.[Average_Days_Open] > 21 AND B.[Average_Days_Open] <=28) THEN
			2
		ELSE
			CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 14 AND B.[Average_Days_Open] <= 21) THEN
				3
			ELSE
				CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 7 AND B.[Average_Days_Open] <= 14) THEN
					4
				ELSE
					5
				END
			END
		END
	END AS FLOAT)) AS Numeric(10,2)) AS Avg_Score
FROM
	dbo.fn_RepeatDeficiencyByLocation(@Date,@Region,@PK_Security_ID) A,
	dbo.fn_AverageDaysOpenByLocation(@Date,@Curr_Date,@Region,@PK_Security_ID) B
WHERE
		A.[DBA] = B.[DBA] AND
		A.[Region] = B.[Region] AND A.[Region] = @Region
GO
/****** Object:  StoredProcedure [dbo].[Chart_SabaTrainingByRegion]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [Chart_SabaTrainingByRegion]  2009 ,56  
CREATE PROCEDURE [dbo].[Chart_SabaTrainingByRegion]       
(        
 @Year int  ,  
 @UserId numeric(20,0)  
)        
AS       
DECLARE  @Date Datetime  ,@Curr_Date DATETIME    
BEGIN      
SET @Curr_Date = GETDATE()      
    
CREATE TABLE #temp            
(            
 Region nvarchar(50) ,      
 per numeric(18,3)       
)      
      
-- If Passed Date Year is not Current Year then Use Last date of Passed       
IF(@Year != YEAR(@Curr_Date))      
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)      
ELSE      
 SET @Date = @Curr_Date;      
      
print(@Date)    
      
Declare @March Datetime,@April Datetime,@June Datetime,@July Datetime,@Sept Datetime,@Oct Datetime      
      
Set @March =  CAST(('03/31/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @April =  CAST(('04/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @June =  CAST(('06/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @July =  CAST(('07/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @Sept =  CAST(('09/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @Oct =  CAST(('10/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
      
insert into #temp      
select [Region],cast((SUM([Number_Trained])/ Isnull(NullIF(SUM([Number_of_Employees]),0),1) * 100) as numeric(18,3))      
From      
 (select [Number_of_Employees],[Number_Trained],[REGION],[DBA]      
 From       
  (select [PCT].[Number_of_Employees] , [PCT].[Number_Trained] , [PCT].[FK_Property_COPE] ,      
   [PCT].[Date] ,[L].[REGION],[L].[DBA]      
   From      
    [LU_Location] [L],      
    Property_Cope_Saba_Training [PCT],      
    [Property_Cope] [P]       
    where L.Show_On_Dashboard = 'Y' AND [P].[PK_Property_Cope_ID] = [PCT].[FK_Property_COPE]  AND [P].[FK_LU_Location_ID] = [L].[PK_LU_Location_ID]      
  )[PC],      
  (Select max([PCS].[Date]) As [DATE], [PCS].[FK_Property_COPE]      
   From Property_Cope_Saba_Training [PCS]      
 where Year([PCS].[Date]) = @Year    
   Group by [PCS].[FK_Property_COPE]      
  ) [PCMAX]      
  where [PCMAX].[DATE] = [PC].[DATE]       
  and [PCMAX].[FK_Property_COPE] = [PC].[FK_Property_COPE]      
       
 Union      
 Select 0 As [Number_of_Employees],0 AS [Number_Trained],A.[REGION],A.[DBA]      
 From [LU_Location] A      
  Where A.Show_On_Dashboard ='Y' AND A.[PK_LU_Location_ID] NOT IN      
   (Select [FK_LU_Location_ID] From       
     Property_Cope_Saba_Training [PCT],      
     [Property_Cope] [P]       
     where [P].[PK_Property_Cope_ID] = [PCT].[FK_Property_COPE]       
   )      
 )[A]        
where [A].[Region] in  (select [Region] from  [dbo].[GetRegionsForClaimReports] (@UserID))  
 Group By [Region]    
     
Select [Region],      
(case when @Date <= @March then       
 (Case when ([Per] >=25) then 5 when ([Per] <25 AND [Per] >= 20) then 4 when ([Per] <20 AND [Per] >= 15) then 3 when ([Per] <15 AND [Per] >= 10) then 2 when ([Per] <10) then 1 end)      
 when @Date>= @April and @Date <= @June then      
 (Case when ([Per] >=50) then 5 when ([Per] <50 AND [Per] >= 45) then 4 when ([Per] <45 AND [Per] >= 40) then 3 when ([Per] <40 AND [Per] >= 35) then 2 when ([Per] <35) then 1 end)      
 when @Date>= @July and @Date <= @Sept then      
 (Case when ([Per] >=75) then 5 when ([Per] <75 AND [Per] >= 70) then 4 when ([Per] <70 AND [Per] >= 65) then 3 when ([Per] <65 AND [Per] >= 60) then 2 when ([Per] <60) then 1 end)      
 when @Date>= @Oct then      
 (Case when ([Per] >=100) then 5 when ([Per] <100 AND [Per] >= 95) then 4 when ([Per] <95 AND [Per] >= 80) then 3 when ([Per] <80 AND [Per] >= 75) then 2 when ([Per] <75) then 1 end)      
 end)  As [Score]       
From #Temp      
order by [Region]      
Select  Avg(cast((case when @Date <= @March then       
 (Case when ([Per] >=25) then 5 when ([Per] <25 AND [Per] >= 20) then 4 when ([Per] <20 AND [Per] >= 15) then 3 when ([Per] <15 AND [Per] >= 10) then 2 when ([Per] <10) then 1 end)      
 when @Date>= @April and @Date <= @June then      
 (Case when ([Per] >=50) then 5 when ([Per] <50 AND [Per] >= 45) then 4 when ([Per] <45 AND [Per] >= 40) then 3 when ([Per] <40 AND [Per] >= 35) then 2 when ([Per] <35) then 1 end)      
 when @Date>= @July and @Date <= @Sept then      
 (Case when ([Per] >=75) then 5 when ([Per] <75 AND [Per] >= 70) then 4 when ([Per] <70 AND [Per] >= 65) then 3 when ([Per] <65 AND [Per] >= 60) then 2 when ([Per] <60) then 1 end)      
 when @Date>= @Oct then      
 (Case when ([Per] >=100) then 5 when ([Per] <100 AND [Per] >= 95) then 4 when ([Per] <95 AND [Per] >= 80) then 3 when ([Per] <80 AND [Per] >= 75) then 2 when ([Per] <75) then 1 end)      
 end) as numeric(3,2)))[Average_Score]      
From #temp      
      
DROP TABLE #temp      
      
END
GO
/****** Object:  StoredProcedure [dbo].[Chart_SabaTrainingByLocation]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[Chart_SabaTrainingByLocation]  2009,'NCA'    
CREATE PROCEDURE [dbo].[Chart_SabaTrainingByLocation]      
(        
  @Year int    ,    
 @Region nvarchar(50)  ,  
 @UserId numeric(20,0)  
)        
AS   
DECLARE  @Date Datetime  ,@Curr_Date DATETIME    
   
BEGIN    
SET @Curr_Date = GETDATE()      
  
CREATE TABLE #temp          
(          
 Region nvarchar(50) ,    
 per numeric(18,3) ,    
 DBA nvarchar(50),    
 Sonic_Location_Code int    
)    
      
-- If Passed Date Year is not Current Year then Use Last date of Passed       
IF(@Year != YEAR(@Curr_Date))      
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)      
ELSE      
 SET @Date = @Curr_Date;      
      
Declare @March Datetime,@April Datetime,@June Datetime,@July Datetime,@Sept Datetime,@Oct Datetime      
      
Set @March =  CAST(('03/31/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @April =  CAST(('04/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @June =  CAST(('06/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @July =  CAST(('07/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @Sept =  CAST(('09/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
Set @Oct =  CAST(('10/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)      
      
insert into #temp      
select [Region],cast((SUM([Number_Trained])/ Isnull(NullIF(SUM([Number_of_Employees]),0),1) * 100) as numeric(18,3))   --Sum([Number_Trained])    
,[DBA],[Sonic_Location_Code]     
From      
 (select [Number_of_Employees],[Number_Trained],[REGION],[DBA],[Sonic_Location_Code]    
 From       
  (select [PCT].[Number_of_Employees] , [PCT].[Number_Trained] , [PCT].[FK_Property_COPE] ,      
   [PCT].[Date] ,[L].[REGION],[L].[DBA],[L].[Sonic_Location_Code]      
   From      
    [LU_Location] [L],      
    Property_Cope_Saba_Training [PCT],      
    [Property_Cope] [P]       
    where [L].Show_On_Dashboard = 'Y' AND [P].[PK_Property_Cope_ID] = [PCT].[FK_Property_COPE]  AND [P].[FK_LU_Location_ID] = [L].[PK_LU_Location_ID]      
 And [L].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))  
 AND [L].[Region] = @Region    
  )[PC],      
  (Select max([PCS].[Date]) As [DATE], [PCS].[FK_Property_COPE]      
   From Property_Cope_Saba_Training [PCS] ,    
 [Property_Cope][P],    
 [LU_Location] [L]    
 where L.Show_On_Dashboard = 'Y' AND [PCS].[FK_Property_COPE] = [P].[PK_Property_Cope_ID] AND [L].[PK_LU_Location_ID] = [P].[FK_LU_Location_ID]     
 AND [L].[Region] = @Region    
 AND Year([PCS].[Date]) = @Year  
   Group by [PCS].[FK_Property_COPE]      
  ) [PCMAX]      
  where [PCMAX].[DATE] = [PC].[DATE]       
  and [PCMAX].[FK_Property_COPE] = [PC].[FK_Property_COPE]      
       
 Union      
 Select 0 As [Number_of_Employees],0 AS [Number_Trained],A.[REGION],A.[DBA],[Sonic_Location_Code]    
 From [LU_Location] A      
  Where A.Show_On_Dashboard = 'Y' AND [A].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID)) AND A.[PK_LU_Location_ID] NOT IN      
   (Select [FK_LU_Location_ID] From       
     Property_Cope_Saba_Training [PCT],      
     [Property_Cope] [P]   ,    
  [LU_Location] [L]    
     where L.Show_On_Dashboard = 'Y' AND [P].[PK_Property_Cope_ID] = [PCT].[FK_Property_COPE]   AND [L].[PK_LU_Location_ID] = [P].[FK_LU_Location_ID]      
   
   )  AND [A].[Region] = @Region    
 )[A]      
 Group By [Region],[DBA],[Sonic_Location_Code]    
      
Select [DBA],    
(case when @Date <= @March then       
 (Case when ([Per] >=25) then 5 when ([Per] <25 AND [Per] >= 20) then 4 when ([Per] <20 AND [Per] >= 15) then 3 when ([Per] <15 AND [Per] >= 10) then 2 when ([Per] <10) then 1 end)      
 when @Date>= @April and @Date <= @June then      
 (Case when ([Per] >=50) then 5 when ([Per] <50 AND [Per] >= 45) then 4 when ([Per] <45 AND [Per] >= 40) then 3 when ([Per] <40 AND [Per] >= 35) then 2 when ([Per] <35) then 1 end)      
 when @Date>= @July and @Date <= @Sept then      
 (Case when ([Per] >=75) then 5 when ([Per] <75 AND [Per] >= 70) then 4 when ([Per] <70 AND [Per] >= 65) then 3 when ([Per] <65 AND [Per] >= 60) then 2 when ([Per] <60) then 1 end)      
 when @Date>= @Oct then      
 (Case when ([Per] >=100) then 5 when ([Per] <100 AND [Per] >= 95) then 4 when ([Per] <95 AND [Per] >= 80) then 3 when ([Per] <80 AND [Per] >= 75) then 2 when ([Per] <75) then 1 end)      
 end)  As [Score]   ,[Sonic_Location_Code]    
From #Temp      
where [Region]= @Region      
order by [DBA]    
    
Select  Avg(cast((case when @Date <= @March then       
 (Case when ([Per] >=25) then 5 when ([Per] <25 AND [Per] >= 20) then 4 when ([Per] <20 AND [Per] >= 15) then 3 when ([Per] <15 AND [Per] >= 10) then 2 when ([Per] <10) then 1 end)      
 when @Date>= @April and @Date <= @June then      
 (Case when ([Per] >=50) then 5 when ([Per] <50 AND [Per] >= 45) then 4 when ([Per] <45 AND [Per] >= 40) then 3 when ([Per] <40 AND [Per] >= 35) then 2 when ([Per] <35) then 1 end)      
 when @Date>= @July and @Date <= @Sept then      
 (Case when ([Per] >=75) then 5 when ([Per] <75 AND [Per] >= 70) then 4 when ([Per] <70 AND [Per] >= 65) then 3 when ([Per] <65 AND [Per] >= 60) then 2 when ([Per] <60) then 1 end)      
 when @Date>= @Oct then      
 (Case when ([Per] >=100) then 5 when ([Per] <100 AND [Per] >= 95) then 4 when ([Per] <95 AND [Per] >= 80) then 3 when ([Per] <80 AND [Per] >= 75) then 2 when ([Per] <75) then 1 end)      
 end) as numeric(3,2)))[Average_Score]      
From #temp     
where [Region]= @Region      
    
--select * from #temp    
      
DROP TABLE #temp      
    
    
END
GO
/****** Object:  StoredProcedure [dbo].[Chart_SabaTrainingDetail]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[Chart_SabaTrainingDetail]  '12/12/2009'  ,'Lone Star Ford', '2'    
CREATE PROCEDURE [dbo].[Chart_SabaTrainingDetail]        
(          
  @Year int    ,    
 @DBA nvarchar(50)  ,    
 @Sonic_Location_Code varchar(200)  ,  
 @UserID numeric(20,0)  
)          
AS      
DECLARE  @Date Datetime  ,@Curr_Date DATETIME    
  
BEGIN      
SET @Curr_Date = GETDATE()      
  
CREATE TABLE #temp            
(            
 Region nvarchar(50) ,      
 Number_Trained numeric(6,0),      
 Number_of_Employees numeric(6,0),      
 per numeric(18,3) ,      
 DBA nvarchar(50),      
 Sonic_Location_Code int,      
 SabaDate Datetime      
)      
      
-- If Passed Date Year is not Current Year then Use Last date of Passed       
IF(@Year != YEAR(@Curr_Date))      
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)      
ELSE      
 SET @Date = @Curr_Date;      
      
        
Declare @March Datetime,@April Datetime,@June Datetime,@July Datetime,@Sept Datetime,@Oct Datetime        
        
Set @March =  CAST(('03/31/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
Set @April =  CAST(('04/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
Set @June =  CAST(('06/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
Set @July =  CAST(('07/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
Set @Sept =  CAST(('09/30/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
Set @Oct =  CAST(('10/01/' + CAST((@Year) AS VARCHAR(4)) ) AS DATETIME)        
        
insert into #temp        
select [Region],Sum([Number_Trained]),Sum([Number_of_Employees]),cast((SUM([Number_Trained])/ (NullIF(SUM([Number_of_Employees]),0)) * 100) as numeric(18,3))   --Sum([Number_Trained])      
,[DBA],[Sonic_Location_Code],[Date]       
From        
 (select [Number_of_Employees],[Number_Trained],[REGION],[DBA],[Sonic_Location_Code],[PC].[Date]      
 From         
  (select [PCT].[Number_of_Employees] , [PCT].[Number_Trained] , [PCT].[FK_Property_COPE] ,        
   [PCT].[Date] ,[L].[REGION],[L].[DBA],[L].[Sonic_Location_Code]        
   From        
    [LU_Location] [L],        
    Property_Cope_Saba_Training [PCT],        
    [Property_Cope] [P]         
    where L.Show_On_Dashboard = 'Y' AND [P].[PK_Property_Cope_ID] = [PCT].[FK_Property_COPE]  AND [P].[FK_LU_Location_ID] = [L].[PK_LU_Location_ID]     
 And [L].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))     
    AND [L].[DBA] = @DBA AND [L].[Sonic_Location_Code] = @Sonic_Location_Code    
  )[PC],        
  (Select max([PCS].[Date]) As [DATE], [PCS].[FK_Property_COPE]        
   From Property_Cope_Saba_Training [PCS] ,      
 [Property_Cope][P],      
 [LU_Location] [L]      
 where L.Show_On_Dashboard = 'Y' AND [PCS].[FK_Property_COPE] = [P].[PK_Property_Cope_ID] AND [L].[PK_LU_Location_ID] = [P].[FK_LU_Location_ID]    
 And [L].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))     
 AND [L].[DBA] = @DBA AND [L].[Sonic_Location_Code] = @Sonic_Location_Code    
  AND Year([PCS].[Date]) = @Year  
   Group by [PCS].[FK_Property_COPE]        
  ) [PCMAX]        
  where [PCMAX].[DATE] = [PC].[DATE]         
  and [PCMAX].[FK_Property_COPE] = [PC].[FK_Property_COPE]    
 )[A]        
 Group By [Region],[DBA],[Sonic_Location_Code],[Date]      
        
Select [DBA],      
(case when @Date <= @March then         
 (Case when ([Per] >=25) then 'All Pro' when ([Per] <25 AND [Per] >= 20) then 'Starter' when ([Per] <20 AND [Per] >= 15) then 'Second String' when ([Per] <15 AND [Per] >= 10) then 'Water boy' when ([Per] <10) then 'Spectator' end)        
 when @Date>= @April and @Date <= @June then        
 (Case when ([Per] >=50) then 'All Pro' when ([Per] <50 AND [Per] >= 45) then 'Starter' when ([Per] <45 AND [Per] >= 40) then 'Second String' when ([Per] <40 AND [Per] >= 35) then 'Water boy' when ([Per] <35) then 'Spectator' end)        
 when @Date>= @July and @Date <= @Sept then        
 (Case when ([Per] >=75) then 'All Pro' when ([Per] <75 AND [Per] >= 70) then 'Starter' when ([Per] <70 AND [Per] >= 65) then 'Second String' when ([Per] <65 AND [Per] >= 60) then 'Water boy' when ([Per] <60) then 'Spectator' end)        
 when @Date>= @Oct then        
 (Case when ([Per] >=100) then 'All Pro' when ([Per] <100 AND [Per] >= 95) then 'Starter' when ([Per] <95 AND [Per] >= 80) then 'Second String' when ([Per] <80 AND [Per] >= 75) then 'Water boy' when ([Per] <75) then 'Spectator' end)        
 end)  As [Score]   ,[Sonic_Location_Code],[Number_of_Employees],[Number_Trained],[SabaDate],[Per]      
From #Temp        
 where [DBA] = @DBA AND [Sonic_Location_Code] = @Sonic_Location_Code      
order by [DBA]      
    
      
--select * from #temp      
        
DROP TABLE #temp        
      
      
END
GO
/****** Object:  StoredProcedure [dbo].[Chart_FacilityInspectionByRegion]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chart_FacilityInspectionByRegion]
(
	@Year int,@PK_Security_ID DECIMAL(20,0)
)
AS 

DECLARE @Date DATETIME,@Curr_Date DATETIME;

SET @Curr_Date = GETDATE()

-- If Passed Date Year is not Current Year then Use Last date of Passed 
IF(@Year != YEAR(@Curr_Date))
	SET @Date = '31-Dec-' + CAST(@Year AS varchar)
ELSE
	SET @Date = @Curr_Date;

PRINT @Date

SELECT
	A.[Region],
	CASE WHEN A.[Repeat_Deficiencies] > 3 OR B.[Average_Days_Open] > 28 THEN
		1
	ELSE
		CASE WHEN A.[Repeat_Deficiencies] = 3 OR (B.[Average_Days_Open] > 21 AND B.[Average_Days_Open] <=28) THEN
			2
		ELSE
			CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 14 AND B.[Average_Days_Open] <= 21) THEN
				3
			ELSE
				CASE WHEN A.[Repeat_Deficiencies] = 2 OR (B.[Average_Days_Open] > 7 AND B.[Average_Days_Open] <= 14) THEN
					4
				ELSE
					5
				END
			END
		END
	END AS Score INTO #ResultSet
FROM
	dbo.fn_RepeatDeficiencyByRegion(@Date,@PK_Security_ID) A,
	dbo.fn_AverageDaysOpenByRegion(@Date,@Curr_Date,@PK_Security_ID) B
WHERE
	A.[Region] = B.[Region]

SELECT * FROM #ResultSet

SELECT AVG(CAST(Score AS numeric(20,1))) AS Score
FROM #ResultSet
GO
/****** Object:  StoredProcedure [dbo].[Chart_FacilityInspectionDetail]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*       
SET @DBA = 'Lone Star Ford'      
SET @Sonic_Location_Code = '2'      
SET @Curr_date = GETDATE()      
      
Chart_FacilityInspectionDetail 2010,'Data Base Administrator','1'      
*/      
      
CREATE  PROC [dbo].[Chart_FacilityInspectionDetail]      
(      
 @Year int,      
 @DBA varchar(200),       
 @Sonic_Location_Code varchar(200)      
)      
AS      
DECLARE @Repeat_Deficiencies numeric(20,1), @Average_Days_Open numeric(20,1)      
      
DECLARE @Date DATETIME,@Curr_Date DATETIME;      
SET @Curr_Date = GETDATE()      
-- If Passed Date Year is not Current Year then Use Last date of Passed       
IF(@Year != YEAR(@Curr_Date))      
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)      
ELSE      
 SET @Date = @Curr_Date;      
      
PRINT @Date      
      
      
SELECT      
 @Repeat_Deficiencies = SUM(Repeat_Deficiencies)        
 FROM      
  (      
  SELECT       
   D.Region,      
   D.Sonic_Location_Code,      
   D.DBA,      
   D.FK_Inspection_Question_Id,      
   COUNT(D.FK_Inspection_Question_Id) - 1 AS Repeat_Deficiencies      
  FROM      
   (      
   SELECT      
    A.Region,      
    A.Sonic_Location_Code,      
    A.DBA,      
    B.Date,      
    C.FK_Inspection_Id,      
    C.FK_Inspection_Question_Id      
   FROM      
    LU_Location A,      
    Inspection B,      
    Inspection_Responses C      
   WHERE A.Show_On_Dashboard = 'Y' AND  
    C.[Deficiency_Noted] LIKE 'Y' AND     
    A.PK_LU_Location_Id = B.FK_LU_Location_Id AND      
    B.PK_Inspection_Id = C.FK_Inspection_Id AND      
    B.Date IS NOT NULL AND      
    B.Date > '1753-01-01' AND      
    B.Date >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)     
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)    
   ELSE (@Date - 200)    
   END    
 AND B.Date <= @Date AND A.Sonic_Location_Code=@Sonic_Location_Code AND A.DBA = @DBA      
   ) D      
  GROUP BY      
   D.Region,      
   D.Sonic_Location_Code,      
   D.DBA,      
   D.FK_Inspection_Question_Id      
  HAVING      
   COUNT(D.FK_Inspection_Question_Id) > 1      
  ) E      
 GROUP BY       
  E.Region,      
  E.Sonic_Location_Code,      
  E.DBA       
      
      
SELECT      
 @Average_Days_Open = CAST(AVG(Days_Open * 1.0) AS NUMERIC(20,1))      
FROM      
 (      
 SELECT      
  A.Region,      
  A.Sonic_Location_Code,      
  A.DBA,      
  B.Date,      
  C.PK_Inspection_Responses_Id,      
  C.FK_Inspection_Question_Id,      
  CASE WHEN C.[Date_Opened] IS NOT NULL AND C.[Actual_Completion_Date] IS NOT NULL AND      
   C.[Date_Opened] > '1753-01-01' AND C.[Actual_Completion_Date] > '1753-01-01'       
  THEN      
   DATEDIFF(DAY, C.[Date_Opened],C.[Actual_Completion_Date])      
  ELSE      
   CASE WHEN (C.[Date_Opened] IS NOT NULL AND C.[Actual_Completion_Date] IS NOT NULL AND      
    C.[Date_Opened] > '1753-01-01' AND C.[Actual_Completion_Date] = '1753-01-01') OR      
    (C.[Date_Opened] IS NOT NULL AND C.[Actual_Completion_Date] IS NULL AND      
    C.[Date_Opened] > '1753-01-01')      
   THEN      
    DATEDIFF(DAY, C.[Date_Opened],GETDATE())      
   ELSE      
    CASE WHEN ((C.[Date_Opened] IS NOT NULL AND C.[Actual_Completion_Date] IS NOT NULL AND      
     C.[Date_Opened] = '1753-01-01' AND C.[Actual_Completion_Date] = '1753-01-01') OR      
     (C.[Date_Opened] IS NULL AND C.[Actual_Completion_Date] IS NULL)) AND      
     B.[Date] IS NOT NULL AND B.[Date] > '1753-01-01'       
    THEN      
     DATEDIFF(DAY, B.[Date],GETDATE())      
    ELSE      
     CASE WHEN ((C.[Date_Opened] IS NOT NULL AND C.[Actual_Completion_Date] IS NOT NULL AND      
      C.[Date_Opened] = '1753-01-01' AND C.[Actual_Completion_Date] > '1753-01-01') OR      
      (C.[Date_Opened] IS NULL AND C.[Actual_Completion_Date] IS NOT NULL AND      
      C.[Actual_Completion_Date] > '1753-01-01')) AND      
      B.[Date] IS NOT NULL AND B.[Date] > '1753-01-01'       
     THEN      
      DATEDIFF(DAY, B.[Date],C.[Actual_Completion_Date])      
     END      
    END      
   END    
  END AS Days_Open       
 FROM      
  [LU_Location] A,      
  [Inspection] B,      
  [Inspection_Responses] C      
 WHERE  A.Show_On_Dashboard = 'Y' AND  
  C.[Deficiency_Noted] LIKE 'Y' AND     
  A.[PK_LU_Location_Id] = B.[FK_LU_Location_Id] AND      
  B.[Date] IS NOT NULL AND      
  B.[Date] > '1753-01-01' AND A.[Sonic_Location_Code] =  @Sonic_Location_Code AND A.DBA = @DBA AND      
 B.[Date] >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)     
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)    
   ELSE (@Date - 200)    
   END    
 AND B.[Date] <= @Date AND       
  B.[PK_Inspection_Id] = C.[FK_Inspection_Id] --AND A.[Region] = @Region        
 ) D      
GROUP BY      
 D.Region,      
 D.Sonic_Location_Code,      
 D.DBA       
      
SELECT A.Sonic_Location_Code, A.DBA , @Repeat_Deficiencies AS Repeat_Deficiencies, @Average_Days_Open AS Average_Days_Open ,       
 CASE WHEN @Repeat_Deficiencies > 3 OR @Average_Days_Open > 28 THEN      
  'Spectator'      
 ELSE      
  CASE WHEN @Repeat_Deficiencies = 3 OR (@Average_Days_Open > 21 AND @Average_Days_Open <=28) THEN      
   'Water boy'      
  ELSE      
   CASE WHEN @Repeat_Deficiencies = 2 OR (@Average_Days_Open > 14 AND @Average_Days_Open <= 21) THEN      
    'Second String'      
   ELSE      
    CASE WHEN @Repeat_Deficiencies = 2 OR (@Average_Days_Open > 7 AND @Average_Days_Open <= 14) THEN      
     'Starter'      
    ELSE      
     'All Pro'      
    END      
   END      
  END      
 END AS Score      
FROM lu_Location A      
WHERE A.[Sonic_Location_Code] =  @Sonic_Location_Code AND A.DBA = @DBA
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentInvestigationByRegion]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [Chart_IncidentInvestigationByRegion] 2009  
  
CREATE PROCEDURE [dbo].[Chart_IncidentInvestigationByRegion]  
(  
 @Year int, @PK_Security_ID numeric(20,0)  
)  
AS   
  
SELECT E.[Region], AVG(E.[Average_Score]) AS Average_Score INTO #Resultset  
FROM  
 (  
 SELECT D.[Region],  D.[DBA], AVG(D.[Score]) AS Average_Score  
 FROM  
 (  
  SELECT  
   A.[Region],  
   A.[DBA],  
   CASE WHEN B.[Investigative_Quality] = 'All Pro' THEN  
    5.0  
   ELSE  
    CASE WHEN B.[Investigative_Quality] = 'Starter' THEN  
     4.0  
    ELSE  
     CASE WHEN B.[Investigative_Quality] = 'Second String' THEN  
      3.0  
     ELSE  
      CASE WHEN B.[Investigative_Quality] = 'Water boy' THEN  
       2.0  
      ELSE  
       CASE WHEN B.[Investigative_Quality] = 'Spectator' OR B.[Investigative_Quality] IS NULL THEN  
        1.0  
       END  
      END  
     END  
    END  
   END AS Score  
  FROM  
   [LU_Location] A,  
   [Investigation] B,  
   [WC_FR] C  
  WHERE A.Show_On_Dashboard = 'Y' AND  
   A.[PK_LU_Location_Id] = B.[FK_LU_Location_Id] AND  
   B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
   YEAR(C.[Date_Of_Incident]) = @Year AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID))   
  UNION  
  SELECT  
   A.[Region],  A.[DBA], 5.0 AS Score  
  FROM  
   [LU_Location] A  
  WHERE A.Show_On_Dashboard = 'Y' AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID)) AND   
   A.[PK_LU_Location_Id] NOT IN   
   (  
    SELECT [FK_LU_Location_Id]   
    FROM [Investigation] B, [WC_FR] C  
    WHERE B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND YEAR(C.[Date_Of_Incident]) = @Year  
   )  
  ) D  
 GROUP BY   
  D.[Region],  
  D.[DBA]  
 ) E  
GROUP BY  
 E.[Region]  
  
SELECT Z.[Region], Average_Score,   
 CASE WHEN Average_Score > 4.0 THEN 5  
    ELSE  CASE WHEN Average_Score > 3.0 and Average_Score <= 4.0 THEN 4  
 ELSE  CASE WHEN Average_Score > 2.0 and Average_Score <= 3.0 THEN 3  
 ELSE  CASE WHEN Average_Score > 1.0 and Average_Score <= 2.0 THEN 2  
 ELSE  CASE WHEN Average_Score <= 1.0 THEN 1   
 END END END END END AS Score    
FROM #ResultSet AS Z  
ORDER BY  
 Z.[Region]  
  
SELECT CAST(AVG(CAST(CASE WHEN Average_Score > 4.0 THEN 5  
    ELSE  CASE WHEN Average_Score > 3.0 and Average_Score <= 4.0 THEN 4  
 ELSE  CASE WHEN Average_Score > 2.0 and Average_Score <= 3.0 THEN 3  
 ELSE  CASE WHEN Average_Score > 1.0 and Average_Score <= 2.0 THEN 2  
 ELSE  CASE WHEN Average_Score <= 1.0 THEN 1   
 END END END END END AS Numeric(20,2)))AS Numeric(20,1)) AS Score   
FROM #ResultSet AS Z
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentInvestigationByLocation]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Chart_IncidentInvestigationByLocation '2009','A',56  
CREATE PROCEDURE [dbo].[Chart_IncidentInvestigationByLocation]  
(  
 @Year int,  
 @Region varchar(200),  
 @PK_Security_ID numeric(20,0)  
)  
AS   
  
SELECT Z.Sonic_Location_Code, Z.[DBA],   
 CASE WHEN Average_Score > 4.0 THEN 5  
    ELSE  CASE WHEN Average_Score > 3.0 and Average_Score <= 4.0 THEN 4  
 ELSE  CASE WHEN Average_Score > 2.0 and Average_Score <= 3.0 THEN 3  
 ELSE  CASE WHEN Average_Score > 1.0 and Average_Score <= 2.0 THEN 2  
 ELSE  CASE WHEN Average_Score <= 1.0 THEN 1   
 END END END END END AS Score   
FROM (  
  
SELECT  
 D.[Region],  
 D.[DBA],  
 D.[Sonic_Location_Code],  
 CAST(AVG(D.[Score]) AS NUMERIC(20,1)) AS Average_Score  
FROM  
(  
SELECT  
 A.[Region],  
 A.[DBA],  
 A.[Sonic_Location_Code],  
 CASE WHEN B.[Investigative_Quality] = 'All Pro' THEN  
  5.0  
 ELSE  
  CASE WHEN B.[Investigative_Quality] = 'Starter' THEN  
   4.0  
  ELSE  
   CASE WHEN B.[Investigative_Quality] = 'Second String' THEN  
    3.0  
   ELSE  
    CASE WHEN B.[Investigative_Quality] = 'Water boy' THEN  
     2.0  
    ELSE  
     CASE WHEN B.[Investigative_Quality] = 'Spectator' OR B.[Investigative_Quality] IS NULL THEN  
      1.0  
     END  
    END  
   END  
  END  
 END AS Score  
FROM  
 [LU_Location] A,  
 [Investigation] B,  
 [WC_FR] C  
WHERE A.Show_On_Dashboard = 'Y' AND   
 A.[PK_LU_Location_Id] = B.[FK_LU_Location_Id] AND  
 B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
 YEAR(C.[Date_Of_Incident]) = @YEAR AND  
 A.[Region] = @Region AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID))   
UNION  
SELECT  
 A.[Region],  
 A.[DBA],  
 A.[Sonic_Location_Code],  
 5.0 AS Score  
FROM  
 [LU_Location] A  
WHERE A.Show_On_Dashboard = 'Y' AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID)) AND  
 A.[PK_LU_Location_Id] NOT IN   
 (  
 SELECT   
  [FK_LU_Location_Id]   
 FROM   
  [Investigation] B,  
  [WC_FR] C  
 WHERE  
  B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
  YEAR(C.[Date_Of_Incident]) = @YEAR  
 ) AND  
 A.[Region] = @Region  
) D  
GROUP BY   
 D.[Region],  
 D.[Sonic_Location_Code],  
 D.[DBA]  
) Z  
ORDER BY  
 Z.[Sonic_Location_Code],  
 Z.[DBA]  
  
  
SELECT   
 CAST(AVG(CAST(D.[Score] AS NUMERIC(20,2))) AS NUMERIC(20,2)) AS Average_Score  
FROM  
(  
SELECT  
 A.[Region],  
 A.[DBA],  
 A.[Sonic_Location_Code],  
 CASE WHEN B.[Investigative_Quality] = 'All Pro' THEN  
  5.0  
 ELSE  
  CASE WHEN B.[Investigative_Quality] = 'Starter' THEN  
   4.0  
  ELSE  
   CASE WHEN B.[Investigative_Quality] = 'Second String' THEN  
    3.0  
   ELSE  
    CASE WHEN B.[Investigative_Quality] = 'Water boy' THEN  
     2.0  
    ELSE  
     CASE WHEN B.[Investigative_Quality] = 'Spectator' OR B.[Investigative_Quality] IS NULL THEN  
      1.0  
     END  
    END  
   END  
  END  
 END AS Score  
FROM  
 [LU_Location] A,  
 [Investigation] B,  
 [WC_FR] C  
WHERE A.Show_On_Dashboard = 'Y' AND  
 A.[PK_LU_Location_Id] = B.[FK_LU_Location_Id] AND  
 B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
 YEAR(C.[Date_Of_Incident]) = @YEAR AND  
 A.[Region] = @Region  AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID))   
UNION  
SELECT  
 A.[Region],  
 A.[DBA],  
 A.[Sonic_Location_Code],  
 5.0 AS Score  
FROM  
 [LU_Location] A  
WHERE  A.Show_On_Dashboard = 'Y' AND A.PK_LU_Location_ID IN (SELECT PK_LU_Location_ID FROM [dbo].[GetUserLocations](@PK_Security_ID)) AND  
 A.[PK_LU_Location_Id] NOT IN   
 (  
 SELECT   
  [FK_LU_Location_Id]   
 FROM   
  [Investigation] B,  
  [WC_FR] C  
 WHERE  
  B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
  YEAR(C.[Date_Of_Incident]) = @YEAR  
 ) AND  
 A.[Region] = @Region  
) D  
GROUP BY  D.[Region]
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentInvestigationDetail]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Chart_IncidentInvestigationDetail]   
(  
 @Year int,    
 @DBA varchar(200),     
 @Sonic_Location_Code varchar(200)    
)  
AS   
  
SELECT  Z.[Region],  Z.[DBA], Z.Sonic_location_Code, Count(*) AS NoOfInvestigations, Avg(Score) as Score,  
 CASE WHEN Avg(Score) > 4.0 THEN 'All Pro'  
    ELSE  CASE WHEN Avg(Score) > 3.0 and Avg(Score) <= 4.0 THEN 'Starter'  
 ELSE  CASE WHEN Avg(Score) > 2.0 and Avg(Score) <= 3.0 THEN 'Second String'  
 ELSE  CASE WHEN Avg(Score) > 1.0 and Avg(Score) <= 2.0 THEN 'Water boy'  
 ELSE  CASE WHEN Avg(Score) <= 1.0 THEN 'Spectator'  
 END END END END END AS Performance_Level  
FROM (  
SELECT  
 A.[Region],  
 A.[DBA],  
 A.Sonic_location_Code,  
 CASE WHEN B.[Investigative_Quality] = 'All Pro' THEN  
  5.0  
 ELSE  
  CASE WHEN B.[Investigative_Quality] = 'Starter' THEN  
   4.0  
  ELSE  
   CASE WHEN B.[Investigative_Quality] = 'Second String' THEN  
    3.0  
   ELSE  
    CASE WHEN B.[Investigative_Quality] = 'Water boy' THEN  
     2.0  
    ELSE  
     CASE WHEN B.[Investigative_Quality] = 'Spectator' OR B.[Investigative_Quality] IS NULL THEN  
      1.0  
     END  
    END  
   END  
  END  
 END AS Score,[Investigative_Quality],C.[Date_Of_Incident]  
FROM  
 [LU_Location] A,  
 [Investigation] B,  
 [WC_FR] C  
WHERE A.Show_On_Dashboard ='Y' AND  
 A.[PK_LU_Location_Id] = B.[FK_LU_Location_Id] AND  
 B.[FK_WC_FR_Id] = C.[PK_WC_FR_Id] AND  
 YEAR(C.[Date_Of_Incident]) = @Year AND  
 A.Sonic_location_Code = @Sonic_Location_Code and DBA = @DBA  
    
) Z  
Group By   
Z.[Region],  Z.[DBA], Z.Sonic_location_Code
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentReductionByLocation]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chart_IncidentReductionByLocation]  -- 2009,'A'        
(            
 @Year int  ,          
 @Region nvarchar(200),    
 @UserID numeric(20,0)    
)            
AS   
BEGIN    
SELECT   
 E.[Region],  
 E.[DBA],   
 AVG(E.[Score]) AS Score  ,E.[Sonic_Location_Code]   
FROM   
 (   
 SELECT   
  D.[Region],   
  D.[DBA],   
  CASE WHEN D.[Cause_Count] > 4 THEN   
   1          
  ELSE          
   CASE WHEN D.[Cause_Count] = 4 THEN          
    2          
   ELSE          
    CASE WHEN D.[Cause_Count] = 3 THEN          
     3          
    ELSE          
     CASE WHEN D.[Cause_Count] = 2 THEN          
      4          
     ELSE          
      5          
     END          
    END          
   END          
  END AS [Score]  ,D.[Sonic_Location_Code]        
 FROM          
  (          
            
  SELECT          
   C.[Region],          
   C.[DBA],          
   COUNT(A.[Sonic_Cause_Code]) AS Cause_Count  ,C.[Sonic_Location_Code]        
  FROM          
   [Investigation] A,          
   [WC_FR] B,          
   [LU_Location] C          
  WHERE  C.Show_On_Dashboard = 'Y' AND     
   A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND          
   YEAR(B.[Date_Of_Incident]) = @Year AND          
   A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
   (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR          
   LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2')) AND          
   C.[Region] = @Region          
 AND [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))    
  GROUP BY          
   C.[Region],          
   C.[DBA],        
 C.[Sonic_Location_Code]           
  UNION          
  SELECT          
   C.[Region],          
   C.[DBA],          
   0 AS [Cause_Count]  ,        
 C.[Sonic_Location_Code]        
  FROM          
   [LU_Location] C          
  WHERE  C.Show_On_Dashboard = 'Y' AND     
   C.[Region] = @Region AND          
   C.[PK_LU_Location_Id] NOT IN          
   (          
   SELECT          
    A.[FK_LU_Location_Id]          
   FROM          
    [Investigation] A,          
    [WC_FR] B,          
    [LU_Location] C          
   WHERE C.Show_On_Dashboard = 'Y' AND  
    A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND          
    YEAR(B.[Date_Of_Incident]) = @Year AND          
    A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
    (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR          
    LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))          
   )     
 And [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))         
  GROUP BY          
   C.[Region],          
   C.[DBA]  ,C.[Sonic_Location_Code]        
  ) D          
) E           
GROUP BY          
 E.[Region],          
 E.[DBA]  ,E.[Sonic_Location_Code]        
ORDER BY          
 E.[Region],          
 E.[DBA]  ,E.[Sonic_Location_Code]       
      
      
      
SELECT      
 AVG(cast (E.[Score] as Numeric(20,1)))  Average_Score       
FROM          
 (          
 SELECT          
  D.[Region],          
  D.[DBA],          
  CASE WHEN D.[Cause_Count] > 4 THEN          
   1          
  ELSE          
   CASE WHEN D.[Cause_Count] = 4 THEN          
    2          
   ELSE          
    CASE WHEN D.[Cause_Count] = 3 THEN          
     3          
    ELSE          
     CASE WHEN D.[Cause_Count] = 2 THEN          
      4          
     ELSE          
      5          
     END          
    END          
   END          
  END AS [Score]  ,D.[Sonic_Location_Code]        
 FROM          
  (          
            
  SELECT          
   C.[Region],          
   C.[DBA],          
   COUNT(A.[Sonic_Cause_Code]) AS Cause_Count  ,C.[Sonic_Location_Code]        
  FROM          
   [Investigation] A,          
   [WC_FR] B,          
   [LU_Location] C   
  WHERE  C.Show_On_Dashboard = 'Y' AND  
   A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND          
   YEAR(B.[Date_Of_Incident]) = @Year AND          
   A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
   (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR          
   LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2')) AND          
   C.[Region] = @Region          
 And [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))    
  GROUP BY          
   C.[Region],          
   C.[DBA],        
 C.[Sonic_Location_Code]           
  UNION          
  SELECT          
   C.[Region],          
   C.[DBA],          
   0 AS [Cause_Count]  ,        
 C.[Sonic_Location_Code]        
  FROM          
   [LU_Location] C          
  WHERE  C.Show_On_Dashboard = 'Y' AND  
   C.[Region] = @Region AND          
   C.[PK_LU_Location_Id] NOT IN          
   (          
   SELECT          
    A.[FK_LU_Location_Id]          
   FROM          
    [Investigation] A,          
    [WC_FR] B,          
    [LU_Location] c          
   WHERE  C.Show_On_Dashboard = 'Y' AND  
    A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND          
    YEAR(B.[Date_Of_Incident]) = @Year AND          
    A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
    (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR          
    LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))          
   )          
 And [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))    
  GROUP BY          
   C.[Region],          
   C.[DBA]  ,C.[Sonic_Location_Code]        
  ) D          
) E      
END
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentReductionDetail]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [Chart_IncidentReductionDetail] 2009,'Fort Mill Ford','3',56   
CREATE Proc [dbo].[Chart_IncidentReductionDetail]   
(        
 @Year int,        
 @DBA nvarchar(100)  ,      
 @Sonic_Location_Code nvarchar(100)    ,  
 @UserID numeric(20,0)  
)        
As        
      
Begin      
SELECT        
 E.[DBA],        
 E.[Sonic_Location_Code],      
  SUM((CASE WHEN (LEFT(E.[Sonic_Cause_Code],2) = ('S1')) then E.[Cause_Count] end)) AS Cause_CountS1 ,        
  SUM((CASE WHEN (LEFT(E.[Sonic_Cause_Code],2) = ('S2'))  then E.[Cause_Count] end)) AS Cause_CountS2,      
  SUM((CASE WHEN (LEFT(E.[Sonic_Cause_Code],4) = ('S0-1')) THEN E.[Cause_Count] end)) AS Cause_CountS01 ,        
  SUM((CASE WHEN (LEFT(E.[Sonic_Cause_Code],4) = ('S0-2')) THEN E.[Cause_Count] end)) AS Cause_CountS02   
FROM        
 (        
 SELECT         
  D.[DBA],        
  D.[Sonic_Location_Code],D.[Sonic_Cause_Code]   ,  
  D.Cause_Count  
 FROM        
  ( SELECT C.[DBA],  COUNT(A.[Sonic_Cause_Code]) AS Cause_Count  ,C.[Sonic_Location_Code],A.[Sonic_Cause_Code]      
 FROM        
  [Investigation] A,        
  [WC_FR] B,        
  [LU_Location] C        
  WHERE C.Show_On_Dashboard = 'Y' AND  
  A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND        
  YEAR(B.[Date_Of_Incident]) = @Year AND        
  A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND        
  (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR        
  LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2')) AND        
  C.[DBA] = @DBA  And C.[Sonic_Location_Code] = @Sonic_Location_Code     
  AND [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))   
  GROUP BY         
  C.[DBA],      
  C.[Sonic_Location_Code],A.[Sonic_Cause_Code]      
  )D        
) E         
GROUP BY         
 E.[DBA]  ,E.[Sonic_Location_Code]      
ORDER BY       
 E.[DBA]  ,E.[Sonic_Location_Code]      
      
Select     
(CASE WHEN D.[Cause_Count] = 1 THEN  'Spectator'  ELSE  CASE WHEN D.[Cause_Count] = 2 THEN  'Water boy'        
    ELSE CASE WHEN D.[Cause_Count] = 3 THEN 'Second String' ELSE  CASE WHEN D.[Cause_Count] = 4 THEN 'Starter'        
    ELSE  'All Pro'  END  END  END  END) AS [Score]    
From    
 (SELECT              
  Avg(CASE WHEN D.[Cause_Count] > 4 THEN  1  ELSE  CASE WHEN D.[Cause_Count] = 4 THEN  2        
    ELSE CASE WHEN D.[Cause_Count] = 3 THEN 3 ELSE  CASE WHEN D.[Cause_Count] = 2 THEN 4        
    ELSE  5  END  END  END  END) AS [Cause_Count]       
 FROM        
  ( SELECT C.[DBA],  COUNT(A.[Sonic_Cause_Code]) AS Cause_Count  ,C.[Sonic_Location_Code]--,A.[Sonic_Cause_Code]      
 FROM        
  [Investigation] A,        
  [WC_FR] B,        
  [LU_Location] C        
  WHERE  C.Show_On_Dashboard = 'Y' AND  
  A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND        
  YEAR(B.[Date_Of_Incident]) = @Year AND        
  A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND        
  (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR        
  LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2')) AND        
  C.[DBA] = @DBA  And C.[Sonic_Location_Code] = @Sonic_Location_Code     
  AND [C].[PK_LU_Location_ID] in (select PK_LU_Location_ID from [dbo].[GetUserLocations] (@UserID))   
  GROUP BY         
  C.[DBA],      
  C.[Sonic_Location_Code]      
  )D       
  Group by       
  D.[DBA]   )D     
END
GO
/****** Object:  StoredProcedure [dbo].[Chart_WCCLaimMgmtByRegion]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[Chart_WCCLaimMgmtByRegion] 2009   
CREATE PROCEDURE [dbo].[Chart_WCCLaimMgmtByRegion]      
(      
 @Year int,    
 @PK_Security_ID numeric(20,0) = null      
)      
AS       
      
Declare @Multiplier numeric(10,5)      
      
select @Multiplier = (90.0/103.0)      
      
      
DECLARE @Date DATETIME,@Curr_Date DATETIME;      
      
SET @Curr_Date = GETDATE()      
      
-- If Passed Date Year is not Current Year then Use Last date of Passed       
IF(@Year != YEAR(@Curr_Date))      
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)      
ELSE      
 SET @Date = @Curr_Date;      
      
PRINT @Date      
      
select * into #TEMP from       
(      
 select L.Region, L.State, W.Date_Reported_To_Sonic, DateDiff(d,C.Date_Entered, case when C.Date_Closed is null then getdate() else C.Date_Closed end) as Days      
 from WC_FR W inner join Workers_Comp_Claims C on W.PK_WC_FR_Id = C.Associated_First_Report      
 inner join LU_Location L on C.FK_Insured_Location_Code = L.Sonic_Location_Code      
 where L.Show_On_Dashboard ='Y' And isnull(convert(varchar,Date_Reported_To_Sonic,101), '01/01/1753') <> '01/01/1753'       
 and (Date_Reported_To_Sonic >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)   
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)  
   ELSE (@Date - 200)  
   END   
 and Date_Reported_To_Sonic <= @Date)      
 and L.PK_LU_Location_ID in(select PK_LU_Location_ID from [dbo].[GetUserLocations](@PK_Security_ID))    
      
 UNION      
      
 select L.Region,  L.State, W.Date_Reported_To_Sonic, DateDiff(d,C.Date_Entered, case when C.Date_Closed is null then getdate() else C.Date_Closed end) as Days       
 from WC_FR W inner join Workers_Comp_Claims_OH C on W.PK_WC_FR_Id = C.FK_WC_RD_Id      
 inner join LU_Location L on W.FK_LU_Location = L.PK_LU_Location_ID      
 where l.Show_On_Dashboard = 'Y' and isnull(convert(varchar,Date_Reported_To_Sonic,101), '01/01/1753') <> '01/01/1753'       
 and (Date_Reported_To_Sonic >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)   
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)  
   ELSE (@Date - 200)  
   END  
 and Date_Reported_To_Sonic <= @Date)     
 and L.PK_LU_Location_ID in(select PK_LU_Location_ID from [dbo].[GetUserLocations](@PK_Security_ID))     
)       
as tmp       
order by Region      
      
      
select RegionList.*,       
Case when isnull(AvgByRegion.AvgDays,0) <= 90 then 5       
  when isnull(AvgByRegion.AvgDays,0) > 90 and isnull(AvgByRegion.AvgDays,0) <= 120 then 4       
  when isnull(AvgByRegion.AvgDays,0) > 120 and isnull(AvgByRegion.AvgDays,0) <= 150 then 3      
  when isnull(AvgByRegion.AvgDays,0) > 150 and isnull(AvgByRegion.AvgDays,0) <= 180 then 2      
  when isnull(AvgByRegion.AvgDays,0) > 180 then 1      
 end as Score      
into #ResultSet      
from      
(select distinct Region from LU_Location where LU_Location.Show_On_Dashboard = 'Y' and Region in (select Region from [dbo].[GetRegionsForClaimReports](@PK_Security_ID))) as RegionList LEFT JOIN       
(select Region, Avg(case when Days > 200 then (200 * @Multiplier) else (Days * @Multiplier) end) as AvgDays from #TEMP group by Region)       
as AvgByRegion      
on RegionList.Region = AvgByRegion.Region      
order by RegionList.Region      
      
select * from #ResultSet      
      
select Avg(Score) AS Score from #ResultSet      
      
drop table #ResultSet      
DROP TABLE #TEMP
GO
/****** Object:  StoredProcedure [dbo].[Chart_WCCLaimMgmtByLocation]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [Chart_WCCLaimMgmtByLocation] 2009,'AL-TN-GA-FL Panhandle' , 56  
CREATE PROCEDURE [dbo].[Chart_WCCLaimMgmtByLocation]    
(    
 @Year int,    
 @Region nvarchar(100),    
 @PK_Security_ID numeric(20,0) = null    
)    
AS     
    
Declare @Multiplier numeric(10,5)    
    
select @Multiplier = (90.0/103.0)    
    
DECLARE @Date DATETIME,@Curr_Date DATETIME;    
    
SET @Curr_Date = GETDATE()    
    
-- If Passed Date Year is not Current Year then Use Last date of Passed     
IF(@Year != YEAR(@Curr_Date))    
 SET @Date = '31-Dec-' + CAST(@Year AS varchar)    
ELSE    
 SET @Date = @Curr_Date;    
    
PRINT @Date    
    
select * into #TEMP from     
(    
 select L.dba, L.State, W.Date_Reported_To_Sonic, DateDiff(d,C.Date_Entered, case when C.Date_Closed is null then getdate() else C.Date_Closed end) as Days    
 from WC_FR W inner join Workers_Comp_Claims C on W.PK_WC_FR_Id = C.Associated_First_Report    
 inner join LU_Location L on C.FK_Insured_Location_Code = L.Sonic_Location_Code    
 where L.Show_On_Dashboard = 'Y' AND isnull(convert(varchar,Date_Reported_To_Sonic,101), '01/01/1753') <> '01/01/1753'     
 and (Date_Reported_To_Sonic >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)   
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)  
   ELSE (@Date - 200)  
   END  
 and Date_Reported_To_Sonic <= @Date)    
 and L.Region = @Region    
 and L.PK_LU_Location_ID in(select PK_LU_Location_ID from [dbo].[GetUserLocations](@PK_Security_ID))    
    
 UNION    
    
 select L.dba,  L.State, W.Date_Reported_To_Sonic, DateDiff(d,C.Date_Entered, case when C.Date_Closed is null then getdate() else C.Date_Closed end) as Days     
 from WC_FR W inner join Workers_Comp_Claims_OH C on W.PK_WC_FR_Id = C.FK_WC_RD_Id    
 inner join LU_Location L on W.FK_LU_Location = L.PK_LU_Location_ID    
 where l.Show_On_Dashboard = 'Y' AND isnull(convert(varchar,Date_Reported_To_Sonic,101), '01/01/1753') <> '01/01/1753'     
 and (Date_Reported_To_Sonic >= CASE WHEN (@Date - 200) < CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)   
   THEN CAST('01-01-' + CAST(DATEPART(YY, @Date) AS nvarchar(4)) AS DATETIME)  
   ELSE (@Date - 200)  
   END   
 and Date_Reported_To_Sonic <= @Date)    
 and L.Region = @Region    
 and L.PK_LU_Location_ID in(select PK_LU_Location_ID from [dbo].[GetUserLocations](@PK_Security_ID))    
)     
as tmp     
order by dba    
    
select dbaList.*,     
Case when isnull(AvgByDba.AvgDays,0) <= 90 then 5     
  when isnull(AvgByDba.AvgDays,0) > 90 and isnull(AvgByDba.AvgDays,0) <= 120 then 4     
  when isnull(AvgByDba.AvgDays,0) > 120 and isnull(AvgByDba.AvgDays,0) <= 150 then 3    
  when isnull(AvgByDba.AvgDays,0) > 150 and isnull(AvgByDba.AvgDays,0) <= 180 then 2    
  when isnull(AvgByDba.AvgDays,0) > 180 then 1    
 end as Score, isnull(cast(AvgByDba.AvgDays as int),0) as Average    
into #ResultSet    
from    
(select dba, State, Sonic_Location_Code from LU_Location where LU_Location.Show_On_Dashboard = 'Y' AND Region = @Region and    
 PK_LU_Location_ID in (select PK_LU_Location_ID from [dbo].[GetUserLocations](@PK_Security_ID))) as dbaList LEFT JOIN     
(select dba, Avg(case when Days > 200 then (200 * @Multiplier) else (Days * @Multiplier) end) as AvgDays from #TEMP group by dba)     
as AvgByDba    
on dbaList.dba = AvgByDba.dba    
order by dbaList.dba    
    
select * from #ResultSet    
    
select Avg(Score) from #ResultSet    
    
drop table #ResultSet    
drop table #TEMP
GO
/****** Object:  StoredProcedure [dbo].[Chart_IncidentReductionByRegion]    Script Date: 05/14/2010 14:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chart_IncidentReductionByRegion] --2009    ,437  
(        
 @Year int      ,  
 @UserID numeric(20,0)  
)        
AS        
Begin      
SELECT                                                                 
 E.[Region],                                                        
 AVG(E.[Score]) AS Score                                            
FROM                                                                   
 (                                                                  
 SELECT                                                             
  D.[Region],                                                    
  CASE WHEN D.[Cause_Count] > 4 THEN                             
   1                                                          
  ELSE                                                           
   CASE WHEN D.[Cause_Count] = 4 THEN                         
    2                                                      
   ELSE                                                       
    CASE WHEN D.[Cause_Count] = 3 THEN                     
     3                                                  
    ELSE                                                   
     CASE WHEN D.[Cause_Count] = 2 THEN                 
      4                                              
     ELSE                                               
      5                                              
     END                                                
    END                                                    
   END                                                        
  END AS [Score]                                                 
 FROM                                                               
  (                                                              
  SELECT                                                         
   C.[Region],                                                
   COUNT([Sonic_Cause_Code]) AS Cause_Count                   
  FROM                                                           
   [Investigation] A,                                         
   [WC_FR] B,                                                 
   [LU_Location] C                                            
  WHERE  C.Show_On_Dashboard = 'Y' AND   
   A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND                      
   YEAR(B.[Date_Of_Incident]) = @Year AND           
   A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
   (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR           
   LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))       
 AND [C].[Region] in  (select [Region] from  [dbo].[GetRegionsForClaimReports] (@UserID))     
  GROUP BY                                                       
   C.[Region]                                                 
  UNION                                                          
  SELECT                                                         
   C.[Region],                                                
   0 AS [Cause_Count]                                         
  FROM                                                           
   [LU_Location] C                                            
  WHERE   C.Show_On_Dashboard = 'Y' AND   
   C.[PK_LU_Location_Id] NOT IN                               
   (                                                          
   SELECT                                                     
    A.[FK_LU_LOcation_Id]                                  
   FROM                                                       
    [Investigation] A,                                     
    [WC_FR] B                                              
   WHERE                                                      
    A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND                  
    YEAR(B.[Date_Of_Incident]) = @Year AND       
    (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR       
    LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))      
   )                  
 AND [C].[Region] in  (select [Region] from  [dbo].[GetRegionsForClaimReports] (@UserID))     
  GROUP BY                                                       
   C.[Region]                                                 
  ) D                                                            
 ) E                     
GROUP BY                                                               
 E.[Region]       
ORDER BY                                                               
 E.[Region]     
    
    
    
SELECT                                                      
 AVG(cast (E.[Score] as numeric(20,1) ) ) As Average_Score                                 
FROM                                                                   
 (                                                                  
 SELECT                                                             
  D.[Region],                                                    
  CASE WHEN D.[Cause_Count] > 4 THEN                             
   1                                                          
  ELSE                                                           
   CASE WHEN D.[Cause_Count] = 4 THEN                         
    2                                                      
   ELSE                                                       
    CASE WHEN D.[Cause_Count] = 3 THEN                     
     3                                                  
    ELSE                                                   
     CASE WHEN D.[Cause_Count] = 2 THEN                 
      4                                              
     ELSE                                               
      5                                              
     END                                                
    END                                                    
   END                                                        
  END AS [Score]                                                 
 FROM                                                               
  (                                                              
  SELECT                                                         
   C.[Region],                                                
   COUNT([Sonic_Cause_Code]) AS Cause_Count                   
  FROM                                                           
   [Investigation] A,                                         
   [WC_FR] B,                                                 
   [LU_Location] C                                            
  WHERE C.Show_On_Dashboard = 'Y' AND                                               
   A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND                      
   YEAR(B.[Date_Of_Incident]) = @Year AND           
   A.[FK_LU_Location_Id] = C.[PK_LU_Location_Id] AND          
   (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR           
   LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))          
   AND [C].[Region] in  (select [Region] from  [dbo].[GetRegionsForClaimReports] (@UserID))  
  GROUP BY                                                       
   C.[Region]                                                 
  UNION                                                          
  SELECT                                                         
   C.[Region],                                                
   0 AS [Cause_Count]                                         
  FROM                                                           
   [LU_Location] C                                            
  WHERE C.Show_On_Dashboard = 'Y' AND  
   C.[PK_LU_Location_Id] NOT IN  
   (  
   SELECT   
    A.[FK_LU_LOcation_Id]  
   FROM   
    [Investigation] A,   
    [WC_FR] B   
   WHERE   
    A.[FK_WC_FR_Id] = B.[PK_WC_FR_Id] AND   
    YEAR(B.[Date_Of_Incident]) = @Year AND  
    (LEFT(A.[Sonic_Cause_Code],2) IN ('S1', 'S2') OR     
    LEFT(A.[Sonic_Cause_Code],4) IN ('S0-1', 'S0-2'))  
   )  
   AND [C].[Region] in  (select [Region] from  [dbo].[GetRegionsForClaimReports] (@UserID))                                                          
  GROUP BY                                                       
   C.[Region]                                        
  ) D                                                            
 ) E     
END
GO
