 $(function ()
    {
        $(document).on('submit', "#addProdForm", function () {
            var isValidationError = false;
            var errorMessage = '';
            $('input[data-required]').each(
                                              function (index, control) {
                                                  if ($(control).attr('data-required') && $(control).val() == '')
                                                  {
                                                      isValidationError = true;
                                                      errorMessage += control.name + ' is required field\n';
                                                  }
                                              }
                              );
            if (isValidationError) {
                alert(errorMessage);
                return false;
            }
        });
    });