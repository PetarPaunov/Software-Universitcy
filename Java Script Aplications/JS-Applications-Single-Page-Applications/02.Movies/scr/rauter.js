function hideAllViws(){
    document.querySelectorAll('.view-page').forEach(x => x.style.display = 'none');
}
export function showViwe(section){
    hideAllViws();
    section.style.display = 'block';
}