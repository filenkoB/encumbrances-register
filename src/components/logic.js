export function get_button_colour(item){
    if(item.visible_status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
}
export function get_class_colour(item){
    if(item.visible_status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
}
export function change_item_visible_status(item) {
    if(!item.visible_status) item.visible_status = true;
    else item.visible_status = false;
}