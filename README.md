Mysql workbench db table creation script:
    CREATE TABLE Tasks (
      TaskID INT PRIMARY KEY,
      TaskDescription NVARCHAR(255) NOT NULL,
      StartDate DATE NOT NULL,
      ExpectedClosureDate DATE NOT NULL,
      AssignedTo NVARCHAR(100),
      CompletionStatus BIT
  );
  
  
  CREATE TABLE Log (
      LogID INT AUTO_INCREMENT PRIMARY KEY,
      Description TEXT,
      LogLevel VARCHAR(20),
      LogTime DATETIME
  );


scaffolding commands used:
  Scaffold-DbContext "Server=localhost;Port=3306;Database=assignment1;User=root;Password=password;" Pomelo.EntityFrameworkCore.MySql -OutputDir Models -Context MyDbContext -DataAnnotations
  dotnet ef dbcontext scaffold "Server=localhost;Database=CoreSkillsDb;User=root;Password=yourpassword;" Pomelo.EntityFrameworkCore.MySql -o Models --context-dir Models --context CoreSkillsDbContext --force
