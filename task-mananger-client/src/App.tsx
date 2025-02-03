import React from "react";
import axios from "axios";
import { Task } from "./types";

function App() {

  const [tasks, setTasks] = React.useState<Task[]>([]);

  const getTasksAsync = () => {
    axios.get<Task[]>("http://localhost:5242/api/tasks")
      .then((response) => {
        const processedDate = response.data;
        console.log(processedDate);
        setTasks(processedDate)
      })
      .catch((error) => {
        console.error(error);
      });
  };

  React.useEffect(() => {
    getTasksAsync();
  }, []);

  return (
    <>
      <ul>
        {!tasks ? (
          <p>There is no tasks created yet!</p>
        ) : (
          tasks.map((task: Task) => (
            <li key={task.id}>
              <h3>{task.title}</h3>
              <p>{task.description}</p>
            </li>
          ))
        )}
      </ul>
    </>
  )
}

export default App
