//open model function
function openDeleteModal(deleteButton) {
    //pass id and create a node child for title
    const id = deleteButton.getAttribute('data-id');
    const title = document.createElement("em");
    title.textContent = deleteButton.getAttribute('data-title');
    title.id = 'title-child';

    //put the data in the modal
    document.getElementById('delete-id').value = id;
    document.getElementById('delete-title').appendChild(title);

    document.getElementById('modalDelete').showModal();
}

//cancel delete
function closeDeleteModal()
{
    const childNode = document.getElementById('title-child');
    document.getElementById('delete-title').removeChild(childNode);
    document.getElementById('modalDelete').close()
}
