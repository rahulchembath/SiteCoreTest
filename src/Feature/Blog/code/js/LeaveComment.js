(function ($) {
    $("#LeaveCommentSubmit").click(function (e) {
        e.preventDefault();
        var valid = true;
        $("#commentMessage").addClass("d-none");
        $("#commentMessage").removeClass("alert-danger");
        $("#commentMessage").removeClass("alert-info");
        if (!$("#FirstName").val() != "") {

            valid = false;
        }

        if (valid === true && !$("#LastName").val() != "") {
            valid = false;
        }

        if (valid === true && !$("#Comment").val() != "") {
            valid = false;
        }
        if (valid === true && $("#Email").val() != "") {
            if (!isValidEmail($("#Email").val())) {
                $("#commentMessage").removeClass("d-none");
                $("#commentMessage").addClass("alert-danger");
                $("#commentMessage").html($("#hdnInvalidEmail").val());
                return false;
            }
        }
        if (valid) {
            PostComment();
        }
        else {
            $("#commentMessage").removeClass("d-none");
            $("#commentMessage").addClass("alert-danger");
            $("#commentMessage").html($("#hdnFillRequiredFields").val());
        }
    });
    function PostComment() {
        var commentModel = new Object();
        commentModel.FirstName = $("#FirstName").val();
        commentModel.LastName = $("#LastName").val();
        commentModel.CompanyName = $("#CompanyName").val();
        commentModel.Email = $("#Email").val();
        commentModel.Comment = $("#Comment").val();
        commentModel.parentId = $("#hdnParentId").val();
        $.ajax({
            cache: false,
            url: '/api/Sitecore/Comment/PostComment',
            data: JSON.stringify(commentModel),
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            dataType: 'json',
            success: (function (result) {
                if (result.Success) {
                    $("#commentMessage").html(result.Message);
                    $("#commentMessage").addClass("alert-success");
                    $("#commentMessage").removeClass("d-none");
                    $("#CompanyName").val("");
                    $("#Email").val("");
                    $("#Comment").val("");
                }
                else {
                    $("#commentMessage").html(result.Message);
                    $("#commentMessage").addClass("alert-danger");
                    $("#commentMessage").removeClass("d-none");
                }
            }),
            error: (function (xhr, status) {
                $("#commentMessage").html($("#hdnFailedToPost").val());
                $("#commentMessage").addClass("alert-danger");
                $("#commentMessage").removeClass("d-none");
            })
        });
    }

    $("#btnFacebook").click(function (e) {
        var firstName = $("#FirstName").val().trim();
        var lastName = $("#LastName").val().trim();
        var companyName = $("#CompanyName").val().trim();
        var email = $("#Email").val().trim();
        var comment = $("#Comment").val().trim();
        var parentId = $("#hdnParentId").val().trim();
        if (firstName != "" || lastName != "" || companyName != "" || email != "" || comment != "") {
            e.preventDefault();
            var commentViewModel = new Object();
            commentViewModel.FirstName = firstName;
            commentViewModel.LastName = lastName;
            commentViewModel.CompanyName = companyName;
            commentViewModel.Email = email;
            commentViewModel.Comment = comment;
            commentViewModel.parentId = parentId;
            $.ajax({
                cache: false,
                url: '/api/Sitecore/Comment/SetCommentInSession',
                data: JSON.stringify(commentViewModel),
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                success: (function (result) {
                    $("#frmFacebook").submit();
                }),
                error: (function (xhr, status) {
                })
            });

        }
    });
    $("#btnGoogle").click(function (e) {
        var firstName = $("#FirstName").val().trim();
        var lastName = $("#LastName").val().trim();
        var companyName = $("#CompanyName").val().trim();
        var email = $("#Email").val().trim();
        var comment = $("#Comment").val().trim();
        var parentId = $("#hdnParentId").val().trim();
        if (firstName != "" || lastName != "" || companyName != "" || email != "" || comment != "") {
            e.preventDefault();          
            var commentViewModel = new Object();
            commentViewModel.FirstName = firstName;
            commentViewModel.LastName = lastName;
            commentViewModel.CompanyName = companyName;
            commentViewModel.Email = email;
            commentViewModel.Comment = comment;
            commentViewModel.parentId = parentId;
            $.ajax({
                cache: false,
                url: '/api/Sitecore/Comment/SetCommentInSession',
                data: JSON.stringify(commentViewModel),
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                success: (function (result) {
                    $("#frmGoogle").submit();
                }),
                error: (function (xhr, status) {
                })
            });

        }
    });
    $("#btnLinkedin").click(function (e) {
        var firstName = $("#FirstName").val().trim();
        var lastName = $("#LastName").val().trim();
        var companyName = $("#CompanyName").val().trim();
        var email = $("#Email").val().trim();
        var comment = $("#Comment").val().trim();
        var parentId = $("#hdnParentId").val().trim();
        if (firstName != "" || lastName != "" || companyName != "" || email != "" || comment != "") {
            e.preventDefault();
            var commentViewModel = new Object();
            commentViewModel.FirstName = firstName;
            commentViewModel.LastName = lastName;
            commentViewModel.CompanyName = companyName;
            commentViewModel.Email = email;
            commentViewModel.Comment = comment;
            commentViewModel.parentId = parentId;
            $.ajax({
                cache: false,
                url: '/api/Sitecore/Comment/SetCommentInSession',
                data: JSON.stringify(commentViewModel),
                contentType: 'application/json; charset=utf-8',
                type: 'POST',
                dataType: 'json',
                success: (function (result) {
                    $("#frmLinkedin").submit();
                }),
                error: (function (xhr, status) {
                })
            });

        }
    });

    function isValidEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }  
})(jQuery);