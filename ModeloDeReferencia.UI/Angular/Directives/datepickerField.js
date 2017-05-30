app.directive('datepickerField', ['$compile', function ($compile) {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {

            var el = $(element);
            var orientation = attrs["orientation"];
            var maxdate = attrs["maxdate"];
            var mindate = attrs["mindate"];

            var minDateInput = attrs['startDateId'];
            var maxDateInput = attrs['endDateId'];
            
            el.datetimepicker({
                locale: 'pt-BR',
                format: "DD/MM/YYYY",
                icons: {
                    time: 'fa fa-clock-o',
                    date: 'fa fa-calendar',
                    up: 'fa fa-chevron-up',
                    down: 'fa fa-chevron-down',
                    previous: 'fa fa-chevron-left',
                    next: 'fa fa-chevron-right',
                    today: 'fa fa-screenshot',
                    clear: 'fa fa-trash'
                },
                keepOpen: false,
                maxDate: (maxdate) ? new Date : false,
                minDate: (mindate) ? new Date : false,
                widgetPositioning: {
                    horizontal: 'auto',
                    vertical: (orientation) ? orientation : 'auto'
                }
            }).on('dp.change', function (e) {
                el.trigger('input');
                el.trigger('change');

                if (typeof (minDateInput) === 'string') {
                    var $input = $('#' + minDateInput).data("DateTimePicker");

                    if (typeof (e.date) === 'object' && e.date != null) {
                        $input.maxDate(e.date);
                    } else {
                        $input.maxDate(false);
                    }
                }

                if (typeof (maxDateInput) === 'string') {
                    var $input = $('#' + maxDateInput).data("DateTimePicker");

                    if (typeof (e.date) === 'object' && e.date != null) {
                        $input.minDate(e.date);
                    } else {
                        $input.minDate(false);
                    }
                }

                el.blur();
            }).on('dp.hide', function (e) {
                el.trigger('input');
                el.trigger('change');

                el.blur();
            });
            $compile(el);
        }
    };
}]);