//
// Created by Amin Badin [@AminCoder] on 7/16/2020.
// Cv : www.AminCoder.ir
// Mail : dev@yo-lang.org
// Repository : https://github.com/YODevs/YO
// Official Website : www.yo-lang.org
//

//import file;
#include <stdbool.h>
#include <stdio.h>
#include "impfile.h"

extern void import_file(char directory[])
{
    
}



extern bool exist_file(char fileaddress[]) {
    FILE *file;
    if (file = fopen(fileaddress, "r")){
        fclose(file);
        return true;
    }
    return false;
}
