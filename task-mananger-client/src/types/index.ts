export type Task ={
    id: number;
    title: string;
    description: string;
    status: number;
}

export type TaskCreate = Omit<Task, "id">;