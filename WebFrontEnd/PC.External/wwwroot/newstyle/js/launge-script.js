function showTab(n, lang) {
	var x = document.getElementsByClassName("tab");
	x[n].style.display = "block";
	if (n == 0) {
		document.getElementById("prevBtn").style.display = "none";
	} else {
		document.getElementById("prevBtn").style.display = "inline-block";
	}
	if (n == (x.length - 1)) {
		document.getElementById("nextBtn").style.display = "none";
		setTimeout(function(){
		    var $submit = $('<div/>').attr({ onclick: 'return formSubmitClick(this);', id: 'formSubmit' });
		    $(".button-action").append($submit);

		    if (lang == '2') {
                // Arabic
		        $('#formSubmit').text('إنهاء');
		    } else {
                // English
		        $('#formSubmit').text('Finish');
		    }
		    
	    }, 100);

	} else {
		var $submit = $('#formSubmit').remove();
		document.getElementById("nextBtn").style.display = "inline-block";
	}
}
function nextPrev(n, lang) {
	var x = document.getElementsByClassName("tab");
	x[currentTab].style.display = "none";
	currentTab = currentTab + n;

	showTab(currentTab, lang);
	$('body').css({ 'height': 'auto' });

	setTimeout(function () {
	    var body = document.body,
	    html = document.documentElement;
	}, 100);
}

$(document).ready(function () {
	$('#insurance input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "Other") {
	        $("#insurance-other-toggle").show('slow');
	    } else {
	    	$("#insurance-other-toggle").hide('slow');
	    }
	});
	$('#yes-no-smoke-cig input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "Yes") {
	        ////$("#year-smoke-cig, #stick-cig, #quit-smoking-cigarettes, #help-quit-smoking-cig").show('slow');
	        $("#year-smoke-cig, #stick-cig").show('slow');
	    } else {
	        ////$("#year-smoke-cig, #stick-cig, #quit-smoking-cigarettes, #help-quit-smoking-cig").hide('slow');
	    	$("#year-smoke-cig, #stick-cig").hide('slow');
	    }
	});
	$('#yes-no-smoke-shisha input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "Yes") {
	        ////$("#year-smoke-shisha, #smoke-shisha-opt, #will-quit-shisha, #tool-help-quit-shisha, #exposed-atmos").show('slow');
	        $("#year-smoke-shisha, #smoke-shisha-opt, #exposed-atmos").show('slow');
	    } else {
	        ////$("#year-smoke-shisha, #smoke-shisha-opt, #will-quit-shisha, #tool-help-quit-shisha, #exposed-atmos").hide('slow');
	        $("#year-smoke-shisha, #smoke-shisha-opt, #exposed-atmos").hide('slow');
	    }
	});
});

$(document).ready(function(){

    var date_input = $('input[name="date"]');
    date_input.datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
        endDate: '0'
    });
});

function validateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    return (false)
}