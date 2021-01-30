# I use Azure DevOps to construct project and pipelines and Azure portal to deploy resources


1- I fork .NET  web-based application from github

2- I create new project in Azure DevOps and start new pipeline

![image](https://user-images.githubusercontent.com/26122554/106347885-95bc6600-62ca-11eb-912e-9af3d967c6ca.png)

3- I use Github as a source and authurize it using OAuth

![image](https://user-images.githubusercontent.com/26122554/106347915-d1efc680-62ca-11eb-93da-372ae09f6e09.png)

4- Select the forked repository, branch, and press continoue

![image](https://user-images.githubusercontent.com/26122554/106347948-15e2cb80-62cb-11eb-9f25-11d604b28659.png)

5- Next step, I select YAML file to construct the pipeline

![image](https://user-images.githubusercontent.com/26122554/106347957-2c892280-62cb-11eb-8a12-31fd27867c25.png)

6- Select azure-pipeline.yml file from source code

![image](https://user-images.githubusercontent.com/26122554/106347985-517d9580-62cb-11eb-9583-33c13d3bc6d1.png)

7- YAML file contains:

- Trigger to **master** branch for **Continous Integration (CI)** and use Ubuntu 16.04 from in Azure pipelines agents

- Step to Build Docker image from Dockerfile *build.dockerfile* and run unit tests

- Step tp publish test results to *trx* file

- Step to login to the Azure Container Registry which created and explained in next point

- Step to push Docker image into the Azure Container Registry

- Step to publish Artifacts

8- I sign in to Azure portal and create new Container Registry to host Docker image published from pipeline using this simple shell script

*az acr create -g siemens-demo -n siemensdemoacr --sku Basic --admin-enabled true*

9- I create  new service connection to authunticate Azure Subscription

![image](https://user-images.githubusercontent.com/26122554/106348476-37de4d00-62cf-11eb-9015-95ae432e0c09.png)

10- After selecting YAML file in Azure DevOps pipeline, I press *"Sava & queue"* button to start running the pipeline

![image](https://user-images.githubusercontent.com/26122554/106348040-c5b83900-62cb-11eb-9f77-b91f9a872715.png)

11- All steps are run properly and pipeline is finished successfully

![image](https://user-images.githubusercontent.com/26122554/106348069-ff893f80-62cb-11eb-8db6-e8e215be8318.png)

12- I select it and go to Tests to check the passed unit tests

![image](https://user-images.githubusercontent.com/26122554/106348147-b2599d80-62cc-11eb-82ce-40b2ab6064ae.png)

13- I create new pipeline for security and code analysis. I use SonarCloud to demonstrate this step

14- To start using SonarCloud with Azure DevOps, I do the following:

- Create new access token in Azure DevOps with *code Read & write* permissions to use it with SonarCloud

![image](https://user-images.githubusercontent.com/26122554/106348652-64469900-62d0-11eb-919d-ebbd7c9117cd.png)

- Then, login to SonarCloud portal and create new organization to Authunticate with Azure DevOps organization

![image](https://user-images.githubusercontent.com/26122554/106348690-aff94280-62d0-11eb-9ffb-c823aea96ccf.png)

- Setup new project to use it for application analysis and security testing

![image](https://user-images.githubusercontent.com/26122554/106348748-31e96b80-62d1-11eb-9e5b-ab20c6903ed7.png)

15- In security and code analysis pipeline, I create new job and add these tasks to it to run security and code analysis and puplish it to SonarCloud portal

![image](https://user-images.githubusercontent.com/26122554/106348832-edaa9b00-62d1-11eb-8127-1d4d2fe3bbae.png)

- I enable CI to run pipeline automatically on every code check-in

16- After pipeline finishes successfuly, results are published to SonarCloud portal

![image](https://user-images.githubusercontent.com/26122554/106349077-90afe480-62d3-11eb-8a71-46c5a296ab50.png)

![image](https://user-images.githubusercontent.com/26122554/106348977-e9cb4880-62d2-11eb-84ad-953b078a1952.png)

![image](https://user-images.githubusercontent.com/26122554/106348994-ffd90900-62d2-11eb-9eac-32df692615ff.png)

# NOW, All things are cool and ready for next .. 

17- I create new Release pipeline which triggers CI pipeline and contains 3 stages

![image](https://user-images.githubusercontent.com/26122554/106349114-e08eab80-62d3-11eb-838c-fb719bc3bd08.png)

18- The first stage created is for Acceptance Testing. After it runs successufully,  I select it to check test results

![image](https://user-images.githubusercontent.com/26122554/106358783-f70a2680-6316-11eb-9a65-325f3e8f92fc.png)

19- Next stage is *Staging* which runs automatically after *Acceptance Testing* stage ends successfully

20- This stage contains job which deploy application to Azure App service with Containers

21- I create new Azure Azure Service Plan and App service with containers to host the web app

22- I create *a deployment slot* in Azue App Service for Staging before Production

![image](https://user-images.githubusercontent.com/26122554/106349284-7b3bba00-62d5-11eb-95fa-708205e0fa7a.png)

23- After *Staging* stage in release pipeline runs successfully, app is deployed to [Staging URL](https://siemens-demo-app-staging.azurewebsites.net/)
 
24- A Pre-deployment approval is enabled which trigger successfull *Staging* stage and send automatic mail is to me with approval link

25- After I press link in approval mail and press *approve*, production stage starts and deploy app to production

![image](https://user-images.githubusercontent.com/26122554/106358716-84994680-6316-11eb-9c84-1ddacbd8e6a2.png)

![image](https://user-images.githubusercontent.com/26122554/106349509-ff427180-62d6-11eb-9e68-553d43b8d40c.png)

26- After *Production* stage in release pipeline runs successfully, app is deployed to [Production URL](https://siemens-demo-app.azurewebsites.net/)

27- In Azure portal, I create a dashboard to monitor app metrics and performance

![image](https://user-images.githubusercontent.com/26122554/106349752-3a45a480-62d9-11eb-92d9-f4a495ab9da4.png)


