#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <dirent.h>
#include <errno.h>
#include "cli/cli.h"
#include "err/ncerror.h"

bool check_requirement();
bool dir_exist(char * dirloc);

int main(int argcindex, char *argval[]) {
    if(check_requirement() == false)
    {
        return 1;
    }
    if(argcindex == 1)
    {
        init_main_cli();
    }
    return 0;
}

bool check_requirement()
{
    char * sysdir = getenv("windir");
    if(sysdir == NULL)
    {
        set_error("Enviroment Variable Error","System ID / variable \"windir\" not found.\n"
                                              "You can create a system variable called \"windir\" with a value of \"C:\\Windows\"[Example !]",waitfusr);
        return  false;
    }  
    char * dotnetdir32[45];
    char * dotnetdir64[45];
    
    sprintf(dotnetdir32,"%s\\\Microsoft.NET\\Framework\\v3.5",sysdir);
    sprintf(dotnetdir64,"%s\\\Microsoft.NET\\Framework64\\v3.5",sysdir);

    if(dir_exist(dotnetdir32) == false && dir_exist(dotnetdir64) == false){
        set_error("Install the .NET Framework 3.5","You may need the .NET Framework 3.5 to run an app on Windows 10, Windows 8.1, and Windows 8. You can also use these instructions for earlier Windows versions.",waitfusr);
        return false;
    }
    
    return true;
  
}

bool dir_exist(char * dirloc){
    DIR* dir = opendir(dirloc);
    if (dir) {
        closedir(dir);
        return true;
    } else{
        return false;
    }
}