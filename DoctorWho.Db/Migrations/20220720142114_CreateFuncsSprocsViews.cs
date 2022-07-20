using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreateFuncsSprocsViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fnCompanions(@EpisodeId INT)
				RETURNS VARCHAR(MAX) AS
				BEGIN
					DECLARE @c varchar(MAX) = ''

					SELECT
						@c = @c + 
							CASE WHEN len(@c) > 0 THEN ', ' ELSE '' END + 
							c.CompanionName
		
					FROM
						EpisodeCompanions AS ec
						INNER JOIN Companions AS c ON ec.CompanionId = c.CompanionId
					WHERE
						ec.EpisodeId = @EpisodeId
					RETURN @c
				END;");

            migrationBuilder.Sql(@"CREATE FUNCTION fnEnemies(@EpisodeId INT)
				RETURNS VARCHAR(MAX) AS
				BEGIN
					DECLARE @c varchar(MAX) = ''

					SELECT
						@c = @c + 
							CASE WHEN len(@c) > 0 THEN ', ' ELSE '' END + 
							c.EnemyName
		
					FROM
						EpisodeEnemies AS ec
						INNER JOIN Enemies AS c ON ec.EnemyId = c.EnemyId
					WHERE
						ec.EpisodeId = @EpisodeId
					RETURN @c
				END;"
                );

            migrationBuilder.Sql(@"CREATE PROCEDURE spSummariseEpisodes AS
				BEGIN
					SELECT C.CompanionName, Q.Appearences FROM Companions AS C
					INNER JOIN (
						SELECT TOP(3) CompanionId, COUNT(CompanionId) AS Appearences FROM 
							EpisodeCompanions
							GROUP BY CompanionId
							ORDER BY Appearences DESC
						) AS Q ON Q.CompanionId = C.CompanionId

					SELECT E.EnemyName, Q.Appearences FROM Enemies AS E
					INNER JOIN (
						SELECT TOP(3) EnemyID, COUNT(EnemyId) AS Appearences FROM 
							EpisodeEnemies
							GROUP BY EnemyId
							ORDER BY Appearences DESC
						) AS Q ON Q.EnemyId = E.EnemyId
				END;"
                );

            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes AS
				SELECT 
					Title,
					AuthorName,
					DoctorName,
					dbo.fnCompanions(EpisodeId) AS Companions,
					dbo.fnEnemies(EpisodeId) AS Enemies
					FROM Episodes AS E
						LEFT JOIN Authors AS A ON E.AuthorId = A.AuthorId
						LEFT JOIN Doctors AS D ON E.DoctorId = D.DoctorId;"
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE VIEW viewEpisodes;");
			migrationBuilder.Sql("DELETE PROCEDURE spSummariseEpisodes;");
			migrationBuilder.Sql("DELETE FUNCTION fnEnemies;");
			migrationBuilder.Sql("DELETE FUNCTION fnCompanions;");
		}
    }
}
