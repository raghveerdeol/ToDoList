//open model function
function openDeleteModal(deleteButton) {
    //pass id and create a node child for title
    const id = deleteButton.getAttribute('data-id');
    const title = document.createElement("em");
    title.textContent = deleteButton.getAttribute('data-title');

    //put the data in the modal
    document.getElementById('delete-id').value = id;
    document.getElementById('delete-title').appendChild(title);

    document.getElementById('modalDelete').showModal();
}

//cancel delete
function closeDeleteModal()
{
    document.getElementById('modalDelete').close()
}
