window.HolidayManager = function() {
	this._year = 2022;

	this.$_container = $("div.holidays");
	this.$_results = $("div.holidays div.results");
	this.$_countryOptions = $(".country-items a");
	this.$_yearOptions = $(".year-items a");
	this.$_countryButton = $("button.country-button");
	this.$_yearButton = $("button.year-button");
	this.$_yearButtonContainer = $("div.year-button-container");
};
window.HolidayManager.prototype.init = function() {
	var me = this;
	this.$_countryOptions.click(function() {
		var $button = $(this);

		me._countryCode = $button.data("country-code");
		me.$_countryButton.text($button.text());

		me.onCriteriaChange();
	});
	this.$_yearOptions.click(function() {
		var $button = $(this);

		me._year = $button.data("year");
		me.$_yearButton.text($button.text());

		me.onCriteriaChange();
	});
};
window.HolidayManager.prototype.onCriteriaChange = function(countryCode) {
	var countryCode = this._countryCode;
	var year = this._year;

	var url = "http://localhost:24646/api/holiday?CountryCode=" + countryCode + "&Year=" + year;

	var me = this;
	$.ajax({
		type: "GET",
		url: url,
		success: function(data) {
			me.$_results.empty();

			me.renderHolidays(data.holidays);

			me.$_container.removeClass("hide")
			me.$_yearButtonContainer.removeClass("hide")
		},
		error: function() {
			alert("Something went wrong. Please check whether the Holiday service is running.");
		}
	});
};
window.HolidayManager.prototype.renderHolidays = function(holidays) {
	var fragment = document.createDocumentFragment();

	for (var i = 0; i < holidays.length; i++) {
		var even = i % 2 == 1;
		var holidayFragment = this.renderHoliday(holidays[i], even);

		fragment.appendChild(holidayFragment);
	}

	this.$_results.append(fragment);
};
window.HolidayManager.prototype.renderHoliday = function(holiday, even) {
	var row = document.createElement("div");
	row.className = even ? "row even" : "row";

	var dateCell = document.createElement("div");
	dateCell.className = "col-md-3";
	dateCell.innerText = holiday.dateFormatted;

	var nameCell = document.createElement("div");
	nameCell.className = "col-md-3";
	nameCell.innerText = holiday.name;

	var descriptionCell = document.createElement("div");
	descriptionCell.className = "col-md-6";
	descriptionCell.innerText = holiday.description;

	row.appendChild(dateCell);
	row.appendChild(nameCell);
	row.appendChild(descriptionCell);

	return row;
}

$(document).ready(function() {
	new window.HolidayManager().init();
});