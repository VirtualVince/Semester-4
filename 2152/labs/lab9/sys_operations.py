import os
import sys
import socket
import platform

# Get the machine type
machine_type = platform.machine()
print(f"Machine type: {machine_type}")

# Get the processor type
processor_type = platform.processor()
print(f"Processor type: {processor_type}")

# Set the default timeout for a socket to 50 seconds
socket.setdefaulttimeout(50)
print("Default socket timeout set to 50 seconds")

# Get the default socket timeout
timeout = socket.getdefaulttimeout()
print(f"Default socket timeout: {timeout}")

# Get the operating system name
os_name = platform.system()
print(f"Operating system name: {os_name}")

# Get the current process ID
process_id = os.getpid()
print(f"Current process ID: {process_id}")

# Try to fork a new process (Unix-based systems only)
try:
    pid = os.fork()
    if pid > 0:
        print(f"Successfully forked. Parent process with PID: {os.getpid()}")
    else:
        print(f"Child process with PID: {os.getpid()}")
except (AttributeError, OSError):
    print("Fork operation not supported or failed")

# Using os module to write to a file (lower level approach with more control)
fd = os.open("fdpractice.txt", os.O_CREAT | os.O_RDWR)
print(f"Current process ID: {os.getpid()}")

# Write to the file
os.write(fd, b"Some string to write to the file")

try:
    pid = os.fork()
    
    if pid == 0:  # Child process
        print(f"Child process ID: {os.getpid()}")
        # Move pointer back to beginning of file
        os.lseek(fd, 0, os.SEEK_SET)
        # Read up to 100 bytes
        content = os.read(fd, 100)
        print(f"File content: {content.decode('utf-8')}")
        # Close the file
        os.close(fd)
        # Exit the process
        os._exit(0)
    else:  # Parent process
        print(f"Parent process ID: {os.getpid()}")
        # Wait for child process to finish
        os.waitpid(pid, 0)
        # Close the file
        os.close(fd)
except (AttributeError, OSError):
    print("Fork operation not supported or failed")
    os.close(fd)
