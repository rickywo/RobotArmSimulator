# Coding Test

## REPORT

- PLACE will place the robot above the plate in position X,Y. 
- The origin (1,1) can be considered to be the well in at the SOUTH WEST corner of the grid.
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
- MOVE will move the toy robot one well in the direction specified by the command.
- DETECT will sense whether the well directly below is FULL, EMPTY or ERR (if the robot cannot detect the plate)
- DROP place a drop of liquid into the well directly below the robot
- REPORT will announce the X,Y,FULL/EMPTY (the status of the detection of the well below) of the robot arm. This can be in any form, but standard output is sufficient.

- A robot that is not over the plate can choose the ignore the MOVE and REPORT commands.
- Input can be from a file, or from standard input, as the developer chooses.
- Provide test data to exercise the application. Test data should include priming the plate with wells that are EMPTY or FULL.


## Constraints:
- The toy robot must not overshoot  the table during movement. This also includes the initial placement of the toy robot. 
- Any move that would cause the robot to fall must be ignored.

## Example Input and Output:
    
    a)
    PLACE 1,1
    MOVE N
    REPORT
    Output: 2,1,EMPTY

    b) 
    PLACE 1,1
    MOVE E
    REPORT
    Output: 1,2,FULL

    c)
    PLACE 1,2
    MOVE N
    MOVE E
    REPORT
    Output: 2,3,EMPTY
