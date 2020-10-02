class list
{
    constructor(name)
    {
        this.name = name;
    }
    
    createList()
    {
        $('header').addClass("headline");
        $('li').hide().fadeIn(1500);
        $('li').on('click', function () {
            $(this).remove();
        });
    }
}
todoList = new list("todo");
Document.onload = todoList.createList();
