<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Dashbord</li>
    </ol>

    <div>
        <asp:Panel ID="PicPanel" runat="server">
            <div id="da-slider" class="da-slider">
                <div class="da-slide">
					<h2>Warm Welcome</h2>
					<p>"Do something that your future self will thank you for"<br />"Nothing worth having comes easy."</p>
                    
				<%--	<a href="#" class="da-link">Read more</a>--%>
					<div class="da-img"><img src="pictures/exam.png" alt="image01" height="300" width="300"/></div>
				</div>
				<div class="da-slide">
					<h2>Exam Management</h2>
					<p>Examination is an important activity in every institutes, it becomes laborious task for faculties to manage all the stages of exams on papers."<br />"Exam Management is a single window solution for automating complete life cycle of examination.</p>
					<%--<a href="#" class="da-link">Read more</a>--%>
					<div class="da-img"><img src="Slider/images/2.png" alt="image01" /></div>
				</div>
				<div class="da-slide">
					<h2>Supervisior Order/Report</h2>
					<p> Exam Manger allows the Exam-Coordinator to allcoate students(Supervisior Report) dynamicaly at the time of exam per classwise as well as bench wise and faculties(Supervisior Order)per classwises at time of examination.</p>
					<%--<a href="#" class="da-link">Read more</a>--%>
					<div class="da-img"><img src="image/attendance1.png" alt="image01" /></div>
				</div>
				
			<%--	<div class="da-slide">
					<h2>Summary Report</h2>
					<p>Exam Manager will also give summary report for the result of every student. </p>
					<%--<a href="#" class="da-link">Read more</a>
					<div class="da-img"><img src="images/4.png" alt="image01" /></div>
				</div>--%>
				<nav class="da-arrows">
					<span class="da-arrows-prev"></span>
					<span class="da-arrows-next"></span>				</nav>
			</div>
        </asp:Panel>
    </div>
    <div class="four-grids">
        <div class="col-md-3 four-grid">
            <div class="four-agileits">
                <div class="icon">
                    <img src="image/classss.png" style="height: 40px; width: 40px" />

                </div>
                <div class="four-text">
                    <a href="StudentAllocation.aspx">
                        <h3>Class Allocation</h3>
                    </a>

                    <h4></h4>

                </div>

            </div>
        </div>
        <div class="col-md-3 four-grid">
            <div class="four-agileinfo">
                <div class="icon">
                    <img src="image/t4.png" style="height: 40px; width: 40px" />

                </div>
                <div class="four-text">
                    <a href="QuestionPaperEntry.aspx">
                        <h3>Paper Generation</h3>
                    </a>

                    <h4></h4>

                </div>

            </div>
        </div>
        <div class="col-md-3 four-grid">
            <div class="four-w3ls">
                <div class="icon">
                    <img src="image/f.png" style="height: 40px; width: 40px" />
                </div>
                <div class="four-text">
                    <a href="FacultyAllocation.aspx">
                        <h3>Faculty Allocation</h3>
                    </a>

                    <h4></h4>

                </div>

            </div>
        </div>
        <div class="col-md-3 four-grid">
            <div class="four-wthree">
                <div class="icon">
                    <img src="image/r.png" style="height: 40px; width: 40px" />
                </div>
                <div class="four-text">
                    <a href="ResultEntry.aspx">
                        <h3>Result Generation</h3>
                    </a>

                    <h4></h4>

                </div>

            </div>
        </div>
    </div>
    <p>&nbsp;</p>
    <div class="four-grid">
        <div class="col-md-3 four-grid">
            <div class="four-wthree">
                <div class="icon">
                    <img src="image/attendan.png" style="height: 40px; width: 40px" />
                </div>
                <div class="four-text">
                    <a href="Exam_Attendance.aspx">
                        <h3>Exam Attendance</h3>
                    </a>

                    <h4></h4>
                </div>
            </div>
        </div>

    </div>
    <div class="four-grid">
        <div class="col-md-3 four-grid">
            <div class="four-w3ls">
                <div class="icon">

                    <img src="image/time.png" style="height: 40px; width: 40px" />

                </div>
                <div class="four-text">
                    <a href="TimetableEntry.aspx">
                        <h3>Exam Timetable</h3>
                    </a>

                    <h4></h4>
                </div>
            </div>

        </div>


    </div>
</asp:Content>

