<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebApplication1.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Admin Dashboard</h2>

            <asp:Button ID="btn_viewEmployees" runat="server" Text="View All Employees" OnClick="viewEmployees" />
            <asp:Button ID="btn_viewDeptStats" runat="server" Text="View Dept Statistics" OnClick="viewDeptStats" />
            <asp:Button ID="btn_viewRejected" runat="server" Text="View Rejected Medical Leaves" OnClick="viewRejected" />
            <br /><br />
            <asp:Button ID="btn_removeDeductions" runat="server" Text="Remove Resigned Deductions" OnClick="removeDeductions" />

            <br />
            <asp:Label ID="lbl_message" runat="server" Text="" ForeColor="Green"></asp:Label>
            
            <br /><br />
            
            <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="true" EmptyDataText="No data to display">
            </asp:GridView>

            <br /><hr /><br />

            <h3>Update Attendance</h3>

            <asp:Label ID="lbl_empID" runat="server" Text="Employee ID:"></asp:Label>
            <asp:TextBox ID="txt_empID" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lbl_in" runat="server" Text="Check In (HH:MM):"></asp:Label>
            <asp:TextBox ID="txt_checkIn" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lbl_out" runat="server" Text="Check Out (HH:MM):"></asp:Label>
            <asp:TextBox ID="txt_checkOut" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btn_updateAttendance" runat="server" Text="Update Attendance" OnClick="updateAttendance" />
            <br />
            <asp:Label ID="lbl_msg_update" runat="server" Text=""></asp:Label>

            <br /><hr /><br />

            <h3>Add New Holiday</h3>

            <asp:Label ID="lbl_hName" runat="server" Text="Holiday Name:"></asp:Label>
            <asp:TextBox ID="txt_holidayName" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lbl_hStart" runat="server" Text="From Date (YYYY-MM-DD):"></asp:Label>
            <asp:TextBox ID="txt_holidayStart" runat="server" TextMode="Date"></asp:TextBox>
            <br />

            <asp:Label ID="lbl_hEnd" runat="server" Text="To Date (YYYY-MM-DD):"></asp:Label>
            <asp:TextBox ID="txt_holidayEnd" runat="server" TextMode="Date"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btn_addHoliday" runat="server" Text="Add Holiday" OnClick="addHoliday" />
            <br />
            <asp:Label ID="lbl_msg_holiday" runat="server" Text=""></asp:Label>

            <br /><hr /><br />
            <h3>Daily Actions</h3>

            <asp:Button ID="btn_initAttendance" runat="server" Text="Initiate Daily Attendance" OnClick="initiateAttendance" />

            <br />
            <asp:Label ID="lbl_initMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>