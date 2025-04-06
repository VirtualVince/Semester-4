document.addEventListener("DOMContentLoaded", function () {
    // Retrieve the projectId from the hidden field
    const projectId = document.getElementById("projectId").value;
    const commentsSection = document.getElementById("commentsSection");
    const commentForm = document.getElementById("commentForm");

    // Function to load comments
    async function loadComments() {
        try {
            const response = await fetch(`/ProjectManagement/Projects/${projectId}/Comments`);
            const comments = await response.json();
            commentsSection.innerHTML = "";
            comments.forEach(comment => {
                const div = document.createElement("div");
                div.className = "comment";
                div.innerHTML = `<p>${comment.content}</p><small>${new Date(comment.dateCreated).toLocaleString()}</small>`;
                commentsSection.appendChild(div);
            });
        } catch (error) {
            console.error("Error loading comments:", error);
        }
    }

    // Submit comment via AJAX
    commentForm.addEventListener("submit", async function (e) {
        e.preventDefault();
        const formData = new FormData(commentForm);
        try {
            const response = await fetch(`/ProjectManagement/Projects/${projectId}/Comments/create`, {
                method: "POST",
                body: formData,
                headers: {
                    "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            });
            if (!response.ok) {
                const errorMsg = await response.text();
                alert(errorMsg);
            } else {
                await loadComments();
                commentForm.reset();
            }
        } catch (error) {
            console.error("Error posting comment:", error);
        }
    });

    // Load comments initially
    loadComments();
});
