$(document).ready(function () {
    $('#State').change(function () {
        debugger;
        var datavalue = { statename: $('#State').val() };
        $('#City').empty();

        $.ajax({
            type: 'POST',
            url: '@Url.Action("DropdownCity", "Admin")',
            dataType: 'Json',
            data: datavalue,
            success: function (cities) {
                city = cities.ListofCity;
                $.each(city, function (i, city) {
                    $('#City').append('<option>' + city + '</option>');
                });
            },
            error: function (ex) {
                alert("Fail to retrieve city");
            }
        });
    })
})