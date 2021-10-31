# C969

# About Your Performance Assessment Lab Environment
## Windows Credentials
### Username	
LabUser	
### Password	
Passw0rd!	
## MySQL Connection String
### Server	
127.0.0.1	
### Port	
3306	
### Username	
sqlUser	
### Password	
Passw0rd!	
### Database Name	
client_schedule	

### Time limit - You are allotted 2 hours of lab access once you started this lab. However, this time can be extended.
### Note: You will be prompted to extend your lab when there is 30 minutes remaining. Each time you extend your lab, the time remaining will increase by 45 minutes.
- Things that could cancel a lab - There are two ways that labs can be erased and not be recoverable.
- If your lab time reduces to 30 minutes remaining, you will be prompted to extend the lab. If you choose yes, your lab will be extended for an additional 45 minutes. If you choose no, your lab will be erased and unrecoverable.
- Once you save a lab, it remains for 14 days within Learn on Demand data centers. If you resume that lab within the 14 days, you can access the lab again through the same link you used to access this instance; and if you save the lab again, the lab remains for an additional 14 days from that point forward.

## Exporting Your Database
### IMPORTANT You may want to preserve your database for another project, or for more practice. If you would like to export your database, follow these steps.

- Open a terminal or command line utility within @lab.VirtualMachine(Win10).SelectLink and type the following command, replacing {exportedSqlFile.sql} with the name of the file you would like to save it as.
- mysqldump -u sqluser -p schedulingDB > {exportedSqlFile.sql}
- Open a browser within @lab.VirtualMachine(Win10).SelectLink and log into https://onedrive.live.com/about/en-us/signin/ using either your WGU or personal credentials.
- Upload your file and note the location of your exported SQL file.
- After these steps are completed, your database will be available for you to import back into another instance.

Should be using MySQL Workbench 8.0.25.
