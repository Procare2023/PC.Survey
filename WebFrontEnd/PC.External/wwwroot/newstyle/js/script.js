var currentTab = 0;
showTab(currentTab);
function showTab(n) {
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
		    var $submit = $('<div/>').attr({ onclick: 'formSubmitClick();', id: 'formSubmit' }).text('Finish');
			 $(".button-action").append($submit);
	    }, 100);

	} else {
		var $submit = $('#formSubmit').remove();
		document.getElementById("nextBtn").style.display = "inline-block";
		
		document.getElementById("nextBtn").innerHTML = "Next";
	}
	fixStepIndicator(n)
}
function nextPrev(n) {
	var x = document.getElementsByClassName("tab");
	x[currentTab].style.display = "none";
	currentTab = currentTab + n;
	showTab(currentTab);
	$('body').css({ 'height': 'auto' });
	setTimeout(function () {
	    var body = document.body,
	    html = document.documentElement;
	    var height = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight);
	    $('body').css({ 'height': height + 'px' });
	}, 100);
}


function fixStepIndicator(n) {
	var i, x = document.getElementsByClassName("step");
	for (i = 0; i < x.length; i++) {
		x[i].className = x[i].className.replace(" active", "");
	}
	x[n].className += " active";
}

jQuery("#regForm").submit(function(event){
	event.preventDefault();
	setTimeout(function() {
		$('body').css('position', 'inherit');
	}, 1000)
	$('#form-steps').hide();
	$('#contact_results').show();
	
});

$(document).ready(function () {
    var body = document.body,
	html = document.documentElement;
    var height = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight);
    $('body').css({ 'height': height + 'px' });
    $('#diagnosed-div input[type="radio"]').click(function () {
        if ($(this).attr("value") == "No" || $(this).attr("value") == "Maybe") {
            $("#diagnosed-disease-toggle").hide('slow');
        }
        if ($(this).attr("value") == "Yes") {
            $("#diagnosed-disease-toggle").show('slow');

        }
    });
	$('#health-insurance input[type="radio"]').click(function () {
        if ($(this).attr("value") == "No") {
			$("#yes-insurance-toggle").hide('slow');
        }
        if ($(this).attr("value") == "Yes") {
			$("#yes-insurance-toggle").show('slow');

        }
    });
	$('#close-relatives input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "No" || $(this).attr("value") == "Maybe") {
			$("#close-relatives-toggle").hide('slow');
        }
        if ($(this).attr("value") == "Yes") {
			$("#close-relatives-toggle").show('slow');

        }
    });
	$('#experience-stress input[type="radio"]').click(function () {
        if ($(this).attr("value") == "No") {
			$("#experience-stress-toggle").hide('slow');
        }
        if ($(this).attr("value") == "Yes") {
			$("#experience-stress-toggle").show('slow');

        }
	});
	$('#do-you-exercise-regularly input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "No") {
	        $("#what-type-of-exercise-toggle").hide('slow');
	        $("#how-many-days-physically-active-toggle").hide('slow');
	        $("#what-is-total-time-physically-active-toggle").hide('slow');
	    }
	    if ($(this).attr("value") == "Yes") {
	        $("#what-type-of-exercise-toggle").show('slow');
	        $("#how-many-days-physically-active-toggle").show('slow');
	        $("#what-is-total-time-physically-active-toggle").show('slow');
	    }
	});
	$('#are-you-a-smoker input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "No") {
	        $("#for-how-many-years-toggle").hide('slow');
	        $("#how-many-packs-per-day-toggle").hide('slow');
	    }
	    if ($(this).attr("value") == "Yes") {
	        $("#for-how-many-years-toggle").show('slow');
	        $("#how-many-packs-per-day-toggle").show('slow');
	    }
	});
	$('#insurance-opt input[type="radio"]').click(function () {
	    if ($(this).attr("value") == "Other") {
	        $("#other-insurance-toggle").show('slow');
	    } else {
	    	$("#other-insurance-toggle").hide('slow');
	    }
	});
});