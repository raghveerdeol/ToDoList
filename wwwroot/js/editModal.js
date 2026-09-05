//open model function
function openEditModal(editButton) {
    //read data form buttons attribuite
    const id = editButton.getAttribute('data-id');
    const title = editButton.getAttribute('data-title');
    const description = editButton.getAttribute('data-description');
    const important = editButton.getAttribute('data-important') === 'true';
    const completed = editButton.getAttribute('data-completed') === 'true';

    console.log(important,completed);
    //put the data in the modal
    document.getElementById('edit-id').value = id;
    document.getElementById('edit-title').value = title;
    document.getElementById('edit-description').value = description;
    document.getElementById('edit-important').checked = important;
    document.getElementById('edit-completed').checked = completed;

    document.getElementById('modalEdit').showModal();
}

//close edit modal without edits
function closeEditModal()
{
    document.getElementById('modalEdit').close()
}
