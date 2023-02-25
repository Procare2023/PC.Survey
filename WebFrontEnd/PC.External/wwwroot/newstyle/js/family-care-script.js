jQuery("#regForm").submit(function (event) {
    event.preventDefault();
    setTimeout(function () {
        $('body').css('position', 'inherit');
    }, 1000)
    //$('#form-steps').hide();
    //$('#contact_results').show();
});

/* Format Local Date Start */
function extractDate(rawDate, includeTimePart) {

    var returnVal = null;
    if (rawDate != null) {

        if (includeTimePart) {
            returnVal = formatToLocal(rawDate, 'MM/DD/YYYY HH:mm');
        } else {
            returnVal = formatToLocal(rawDate, 'MM/DD/YYYY');
        }
    }
    return returnVal;
}
function formatToLocal(date, format) {
    if (date) { //check if date not null or empty
        date = date.replace('/Date(', '');
        date = date.replace(')', '');
        date = date.replace('/', '');

        var d = new Date();
        d.setTime(parseInt(date));

        formattedDate = moment(d).format(format);
        return formattedDate.toString();
    }
    else {
        return '';
    }
};
/* Format Local Date End */

var parseQueryString = function () {
    var str = window.location.search;
    var objURL = {};
    str.replace(
        new RegExp("([^?=&]+)(=([^&]*))?", "g"),
        function ($0, $1, $2, $3) {
            objURL[$1] = $3;
        }
    );
    return objURL;
};

$(document).ready(function () {
    var dob = $('input[name="dob"]');
    dob.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var marriageDate = $('input[name="marriageDate"]');
    marriageDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var lastclinicvisitDate = $('input[name="last-clinic-visit"]');
    lastclinicvisitDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var lastclinicvisit_1Date = $('input[name="last-clinic-visit-1"]');
    lastclinicvisit_1Date.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var drVisitDate = $('input[name="drVisit"]');
    drVisitDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var surgeryyearDate = $('input[name="surgery-year-1"]');
    surgeryyearDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var reasonlastvisitDate = $('input[name="reason-dental-visit"]');
    reasonlastvisitDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
    var lastmenstrualcycleDate = $('input[name="last-menstrual-cycle"]');
    lastmenstrualcycleDate.datepicker({
        format: 'mm/dd/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '+0d',
    });
});


$(document).ready(function () {
    $('#conditions-1').change(function () {
        $('#hideMedicalissue').slideToggle("fast");
    });
    $('#conditions-28').change(function () {
        $('#condition-type').slideToggle("fast");
    });
    $('#conditions-30').change(function () {
        $('#condition-cancer').slideToggle("fast");
    });
    $('#conditions-31').change(function () {
        $('#condition-other').slideToggle("fast");
    });
    $('#degree-relatives-3').change(function () {
        $('#other-types-of-cancer').slideToggle("fast");
    });
    $('#prescription-medications-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#prescription-medications-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#prescription-medications-toggle").show('slow');
        }
    });
    $('#supplement-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#supplement-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#supplement-toggle").show('slow');
        }
    });
    $('#reaction-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "1") {
            $("#reaction-toggle").show('slow');
        }
        else {
            $("#reaction-toggle").hide('slow');
        }
    });
    $('#illness-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#illness-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#illness-toggle").show('slow');
        }
    });
    $('#surgery-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#surgery-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#surgery-toggle").show('slow');
        }
    });
    $('#immunizations-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#immunizations-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#immunizations-toggle").show('slow');
        }
    });
    $('#immunizations-others input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#immunizations-others-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#immunizations-others-toggle").show('slow');
        }
    });
    $('#smoker-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#habit-div").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#habit-div").show('slow');
        }
    });
    $('#smoking-family-radio input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#smoking-family-relation").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#smoking-family-relation").show('slow');
        }
    });

    $('#pet-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#pet-details").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#pet-details").show('slow');
        }
    });
    $('#experience-stress-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#experience-stress-detail").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#experience-stress-detail").show('slow');
        }
    });
    $('#hospital-admission-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#hospital-admission-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#hospital-admission-toggle").show('slow');
        }
    });
    $('#treatment-received-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#treatment-received-toggle").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#treatment-received-toggle").show('slow');
        }
    });
    $('#immunizations-complete-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "true") {
            $("#immunizations-complete-toggle").hide('slow');
        }
        if ($(this).attr("value") == "false") {
            $("#immunizations-complete-toggle").show('slow');
        }
    });
    $('#foods').change(function () {
        $('#food-list').slideToggle("fast");
    });
    $('#medications').change(function () {
        $('#medication-list').slideToggle("fast");
    });
    $('#psychological-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#psychological-stress-details").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#psychological-stress-details").show('slow');
        }
    });
    $('#exercise-regularly-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#exercise-regularly-detail").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#exercise-regularly-detail").show('slow');
        }
    });
    //$('#health-reason-div input[type="radio"]').click(function () {
    //    if ($(this).attr("value") == "false") {
    //        $("#exercise-regularly-div").show('slow');
    //    }
    //    if ($(this).attr("value") == "true") {
    //        $("#exercise-regularly-div").hide('slow');
    //        //$("#exercise-regularly-detail").hide('slow');
    //    }
    //});
    $('#contraception-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#contraception-detail").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#contraception-detail").show('slow');
        }
    });
    $('#assistance-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "false") {
            $("#assistance-detail").hide('slow');
        }
        if ($(this).attr("value") == "true") {
            $("#assistance-detail").show('slow');
        }
    });
    //$('#en').click(function () {
    //    $('body').addClass('en');
    //    $('body').removeClass('ar');
    //    $('body').attr({ 'dir': 'ltr' });
    //});
    //$('#ar').click(function () {
    //    $('body').addClass('ar');
    //    $('body').removeClass('en');
    //    $('body').attr({ 'dir': 'rtl' });
    //});
});