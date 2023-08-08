using System;
using Simple_Blogging_App.Data;
using Simple_Blogging_App.Manager;

namespace Simple_Blogging_App.Menu
{
    public class Menu
    {
        public PostManager postManager;
        public CommentManager commentManager;

        public Menu()
        {
            postManager = new PostManager();
            commentManager = new CommentManager();
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Simple Blogging Application");
                Console.WriteLine("1. Create Post");
                Console.WriteLine("2. Open Post");
                Console.WriteLine("3. View All Posts");
                Console.WriteLine("4. Edit Post");
                Console.WriteLine("5. Delete Post");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreatePost();
                        break;

                    case "2":
                        OpenPost();
                        break;

                    case "3":
                        ViewAllPosts();
                        break;

                    case "4":
                        EditPost();
                        break;

                    case "5":
                        DeletePost();
                        break;

                    case "6":
                        Console.WriteLine("See you soon, take care!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void CreatePost()
        {
            Console.Write("Enter post title: ");
            var title = Console.ReadLine()!;
            Console.Write("Enter post content: ");
            var content = Console.ReadLine()!;

            var newPost = new Post { Title = title, Content = content };
            postManager.CreatePost(newPost);
            Console.WriteLine("Post created successfully.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }



        private void OpenPost()
        {
            Console.Clear();
            ViewAllPosts();
            Console.WriteLine("Opening a Post");
            Console.WriteLine("------------------");

            Console.Write("Enter post ID to open: ");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                var postToOpen = postManager.GetPostById(postId);
                if (postToOpen != null)
                {
                    
                    
                    while(true){

                        ViewAPost(postId);
                        Console.WriteLine();
                        Console.WriteLine("1. Add Comment");
                        Console.WriteLine("2. Edit Comment");
                        Console.WriteLine("3. Delete Comment");
                        Console.WriteLine("4. View All Comments");
                        Console.WriteLine("5. Back to Posts");
                        Console.Write("Choose an option: ");
                        var commentOption = Console.ReadLine();

                        switch (commentOption)
                        {
                            case "1":
                                AddComment(postId);
                                break;
                            case "2":
                                EditComment(postToOpen);
                                break;
                            case "3":
                                DeleteComment(postToOpen);
                                break;
                            case "4":
                                ViewAllComments(postId);
                                break;
                            case "5":
                                return;
                            default:
                                Console.WriteLine("Invalid option.");
                                Console.Write("Press Enter to continue...");
                                Console.ReadLine();
                                break;
                        }
                    }
                }

                else
                    Console.WriteLine("Post not found.");
            }
            else
                Console.WriteLine("Invalid post ID.");
        }


           
        private void AddComment(int postId)
        {
            Console.Clear();
            Console.WriteLine("Adding a Comment");
            Console.WriteLine("------------------");

            Console.Write("Enter comment text: ");
            var commentText = Console.ReadLine()!;

            var newComment = new Comment { Text = commentText, PostId = postId };
            commentManager.CreateComment(newComment);
            Console.WriteLine("Comment added successfully.");

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void EditComment(Post post)
        {
            Console.Clear();
            Console.WriteLine("Editing a Comment");
            Console.WriteLine("------------------");

            Console.Write("Enter comment index to edit: ");
            if (int.TryParse(Console.ReadLine(), out int editIndex) && editIndex >= 1 && editIndex <= post.Comments?.Count)
            {
                var commentToEdit = post.Comments.ElementAt(editIndex - 1);
                Console.Write("Enter new comment text: ");
                var newCommentText = Console.ReadLine()!;
                commentToEdit.Text = newCommentText;

                commentManager.UpdateComment(commentToEdit);
                Console.WriteLine("Comment updated successfully.");
            }
            else
                Console.WriteLine("Invalid comment index.");

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void DeleteComment(Post post)
        {
            Console.Clear();
            Console.WriteLine("Deleting a Comment");
            Console.WriteLine("------------------");

            Console.Write("Enter comment index to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteIndex) && deleteIndex >= 1 && deleteIndex <= post.Comments?.Count)
            {
                var commentToDelete = post.Comments.ElementAt(deleteIndex - 1);
                commentManager.DeleteComment(commentToDelete.CommentId);
                Console.WriteLine("Comment deleted successfully.");
            }
            else
                Console.WriteLine("Invalid comment index.");

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }


        private void ViewAllComments(int postId)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t    ------------------");
            Console.WriteLine("\t\t\t        All Comments");
            Console.WriteLine("\t\t\t    ------------------");

            string separator = new string('-', 80);
            Console.WriteLine(separator);
            Console.WriteLine($"{"Comment_Id", -15}{"Post_Id", -20}{"Content", -25}{"Last Updated", -20}");
            Console.WriteLine(separator);

            var Post_comment = postManager.GetPostById(postId);
            
            if (Post_comment != null && Post_comment.Comments != null)
            {
                foreach (var comment in Post_comment.Comments.ToList())
                {
                    string contents = comment.Text?.Length > 20 ? comment.Text.Substring(0, 17) + "..." : comment.Text ?? "N/A";
                    Console.WriteLine($"{comment.CommentId, -15}{comment.PostId, -20}{contents, -25}{comment.CreatedAt, -20}");
                    Console.WriteLine(separator);
                }
            }
            else
                Console.WriteLine("No comments found.");
            
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }


        private void ViewAllPosts()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t    ------------------");
            Console.WriteLine("\t\t\t        All Posts");
            Console.WriteLine("\t\t\t    ------------------");

            string separator = new string('-', 75);
            Console.WriteLine(separator);
            Console.WriteLine($"{"Post_Id", -10}{"Title", -20}{"Content", -25}{"Last Updated", -20}");
            Console.WriteLine(separator);

            var posts = postManager.GetAllPosts();

            foreach (var post in posts)
            {
                string contents = post.Content?.Length > 20 ? post.Content.Substring(0, 17) + "..." : post.Content ?? "N/A";
                Console.WriteLine($"{post.PostId, -10}{post.Title, -20}{contents, -25}{post.CreatedAt, -20}");
                Console.WriteLine(separator);
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        
        }

        private void ViewAPost(int postId)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t    ------------------");
            Console.WriteLine("\t\t\t      Current Post");
            Console.WriteLine("\t\t\t    ------------------");

            string separator = new string('-', 75);
            Console.WriteLine(separator);
            Console.WriteLine($"{"Post_Id", -10}{"Title", -20}{"Content", -25}{"Last Updated", -20}");
            Console.WriteLine(separator);

            var post = postManager.GetPostById(postId);
            string contents = post.Content?.Length > 20 ? post.Content.Substring(0, 17) + "..." : post.Content ?? "N/A";
            Console.WriteLine($"{post.PostId, -10}{post.Title, -20}{contents, -25}{post.CreatedAt, -20}");
            Console.WriteLine(separator);
        }

        private void EditPost()
        {
            Console.Clear();
            Console.WriteLine("Editing a Post");
            Console.WriteLine("------------------");

            Console.Write("Enter post ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                var postToEdit = postManager.GetPostById(postId);
                if (postToEdit != null)
                {
                    Console.Write("Enter new title: ");
                    var newTitle = Console.ReadLine();
                    Console.Write("Enter new content: ");
                    var newContent = Console.ReadLine();

                    postToEdit.Title = newTitle;
                    postToEdit.Content = newContent;

                    postManager.UpdatePost(postToEdit);
                    Console.WriteLine("Post updated successfully.");
                }
                else
                {
                    Console.WriteLine("Post not found.");
                }
            }
            else
                Console.WriteLine("Invalid post ID.");
            

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void DeletePost()
        {
            Console.Clear();
            Console.WriteLine("Deleting a Post");
            Console.WriteLine("------------------");

            Console.Write("Enter post ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                postManager.DeletePost(postId);
                Console.WriteLine("Post deleted successfully.");
            }
            else
                Console.WriteLine("Invalid post ID.");
            

            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }   
    }
}
