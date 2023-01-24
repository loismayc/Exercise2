namespace Exercise2
{
    namespace Models
    {
        public class TodoItem
        {
            public int id { get; set; }
            public string content { get; set; }
            public string status { get; set; }

            public TodoItem(int id, string content)
            {
                this.id = id;
                this.content = content;
                this.status = "pending";
            }

            public bool Update()
            {
                if (this.status == "pending")
                {
                    this.status = "active";
                    return true;
                }
                else if (this.status == "active")
                {
                    this.status = "done";
                    return true;
                }
                else if (this.status == "done")
                {
                    return false;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}