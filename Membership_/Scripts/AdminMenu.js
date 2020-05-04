$(function () {
    $('[data-admin-menu]').hover(function () {
        $('[data-admin-menu]').toggleClass('open');
    });
    $('[data-admin-menu] ul a').mouseover(function () {
        $(this).css('background-color','#337ab7');
    });
    $('[data-admin-menu] ul a').mouseleave(function () {
        $(this).css('background-color', 'white');
    });
});