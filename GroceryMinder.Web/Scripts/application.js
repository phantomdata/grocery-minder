
// Nasty solution to displaying Bootstrap error messages under .NET
// Source: http://stackoverflow.com/questions/18320483/mvc4-validation-with-razor-and-twitter-bootstrap
$(function () {
    // any validation summary items should be encapsulated by a class alert and alert-danger
    $('.validation-summary-errors').each(function () {
        $(this).addClass('alert');
        $(this).addClass('alert-danger');
    });

    // update validation fields on submission of form
    $('form').submit(function () {
        if ($(this).valid()) {
            $(this).find('div.control-group').each(function () {
                if ($(this).find('span.field-validation-error').length == 0) {
                    $(this).removeClass('has-error');
                    $(this).addClass('has-success');
                }
            });
        }
        else {
            $(this).find('div.control-group').each(function () {
                if ($(this).find('span.field-validation-error').length > 0) {
                    $(this).removeClass('has-success');
                    $(this).addClass('has-error');
                }
            });
            $('.validation-summary-errors').each(function () {
                if ($(this).hasClass('alert-danger') == false) {
                    $(this).addClass('alert');
                    $(this).addClass('alert-danger');
                }
            });
        }
    });

    // check each form-group for errors on ready
    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
            }
        });
    });
});

var page = function () {
    //Update the validator
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest(".form-group").addClass("has-error");
            $(element).closest(".form-group").removeClass("has-success");
        },
        unhighlight: function (element) {
            $(element).closest(".form-group").removeClass("has-error");
            $(element).closest(".form-group").addClass("has-success");
        }
    });
}();

// Nasty solution to allow delete links to work.  Seriously .NET, its 2016.
// Get with the program.

$(function() {
    $('a.delete').click(function() {
        if (confirm("Are you sure you want to delete that?") == false) {
            return false;
        }

        var $this = $(this);

        $.ajax({
            type: "POST", // Really?  .NET doesn't even support DELETE
            url: $this.attr("href"),
            success: function () { location.reload(); },
            error: function (data) { console.log(data); alert("Something went wrong while we tried to do that."); }
        });

        $this.remove(); // Prevent extra clicks.
        return false;
    });
});

// Horrible autofocus on first form element if its present
$(function () {
    var el = $('input[type="text"]').first();
    console.log(el);
    if (el) {
        el.focus();
    }
});