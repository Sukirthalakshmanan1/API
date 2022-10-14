create table marks(student_id int primary key,student_name varchar(20),subject_marks int)

insert into marks values(1,'Ram',450);

CREATE PROCEDURE [dbo].sp_Deletemarks
	@p_id int
	
AS
	Delete from marks
	where student_id=@p_id;
RETURN 0

--find
CREATE PROCEDURE [dbo].sp_Findmarks
	@p_studid int,
	  @p_mark_studname varchar(20) output,
	  @p_marks_submarks int output

	

AS
	SELECT
	@p_mark_studname=student_name,@p_marks_submarks=subject_marks 
	from marks	where student_id=@p_studid;

RETURN 0

--update

CREATE PROCEDURE [dbo].[Updatemarks]

      @p_studid int,
	  @p_studname varchar(20),
	  @p_submarks int
AS

BEGIN

    

      UPDATE  marks SET student_name = @p_studname,subject_marks=@p_submarks
	

      WHERE student_id=@p_studid

END