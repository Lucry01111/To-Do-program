Imports System
Imports System.Collections.Generic

Module ToDoApp
    ' List to hold tasks
    Dim tasks As New List(Of Task)()

    ' Class to represent a task
    Class Task
        Public TaskName As String
        Public Completed As Boolean
    End Class

    Sub Main()
        Dim choice As String

        Do
            Console.WriteLine()
            Console.WriteLine("1. Add Task")
            Console.WriteLine("2. List Tasks")
            Console.WriteLine("3. Complete Task")
            Console.WriteLine("4. Delete Task")
            Console.WriteLine("5. Exit")
            Console.Write("Choose an option: ")
            choice = Console.ReadLine()

            Select Case choice
                Case "1"
                    AddTask()
                Case "2"
                    ListTasks()
                Case "3"
                    CompleteTask()
                Case "4"
                    DeleteTask()
                Case "5"
                    Console.WriteLine("Exiting To-Do App. Goodbye!")
                Case Else
                    Console.WriteLine("Invalid option. Please choose a valid one.")
            End Select

        Loop While choice <> "5"
    End Sub

    ' Function to add a task to the list
    Sub AddTask()
        Console.Write("Enter the task: ")
        Dim taskName As String = Console.ReadLine()
        Dim newTask As New Task()
        newTask.TaskName = taskName
        newTask.Completed = False
        tasks.Add(newTask)
        Console.WriteLine("Task '" & taskName & "' added.")
    End Sub

    ' Function to list all tasks
    Sub ListTasks()
        If tasks.Count = 0 Then
            Console.WriteLine("No tasks available.")
            Return
        End If

        For i As Integer = 0 To tasks.Count - 1
            Dim status As String = If(tasks(i).Completed, "✔️", "❌")
            Console.WriteLine((i + 1).ToString() & ". " & tasks(i).TaskName & " [" & status & "]")
        Next
    End Sub

    ' Function to complete a task
    Sub CompleteTask()
        Console.Write("Enter the task number to complete: ")
        Dim taskNumber As Integer

        If Integer.TryParse(Console.ReadLine(), taskNumber) AndAlso taskNumber > 0 AndAlso taskNumber <= tasks.Count Then
            tasks(taskNumber - 1).Completed = True
            Console.WriteLine("Task '" & tasks(taskNumber - 1).TaskName & "' completed.")
        Else
            Console.WriteLine("Invalid task number.")
        End If
    End Sub

    ' Function to delete a task
    Sub DeleteTask()
        Console.Write("Enter the task number to delete: ")
        Dim taskNumber As Integer

        If Integer.TryParse(Console.ReadLine(), taskNumber) AndAlso taskNumber > 0 AndAlso taskNumber <= tasks.Count Then
            Dim removedTask As Task = tasks(taskNumber - 1)
            tasks.RemoveAt(taskNumber - 1)
            Console.WriteLine("Task '" & removedTask.TaskName & "' deleted.")
        Else
            Console.WriteLine("Invalid task number.")
        End If
    End Sub
End Module