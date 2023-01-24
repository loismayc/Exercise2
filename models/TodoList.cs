namespace Exercise2 {
    namespace Models {

        public class TodoList{
        public int id { get; set; }
        public string name { get; set; }
        public List<TodoItem> todoItems { get; set; }

            public TodoList (int id, string name){
                this.id = id;
                this.name = name;

                this.todoItems = new List<TodoItem>();
            }

            public void AddTodoItem (TodoItem item){
                this.todoItems.Add(item);
                
            }

            public void RemoveTodoItem (int id){
                this.todoItems.RemoveAll(i => this.id == id);
            }
        }
    }
}