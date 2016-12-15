<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSONObject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                //url: "Default.aspx/GetCustomers",
                url: "Default.aspx/GetPatient",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        function OnSuccess(response) {
            var table = $("#dvPatient table").eq(0).clone(true);
            var patient = response.d;
            $("#dvPatient table").eq(0).remove();
            $(patient).each(function () {
                $(".hn", table).html(this.HN);
                $(".name", table).html(this.FullName);
                $(".age", table).html(this.age);
                $("#dvPatient").append(table).append("<br />");
                table = $("#dvPatient table").eq(0).clone(true);
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dvPatient">
            <table class="tblPatient" cellpadding="2" cellspacing="0" border="1">
                <tr>
                    <th>
                        <b><u><span class="name"></span></u></b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <b>HN: </b><span class="hn"></span>
                        <br />
                        <b>Age: </b><span class="age"></span>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
