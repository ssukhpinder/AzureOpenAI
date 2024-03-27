Learnings include creating Azure Open AI services, deploying GPT models, interacting with GPT in Playground, and optimizing model performance with parameters.

## Introduction

The Microsoft team has recently launched an Open AI challenge, in which a developer can learn how to build Azure AI solutions and apps.

### Prerequisite

* Experience working with Azure and Azure portals.

* An understanding of generative AI.

## Getting Started

### Step 1: Navigate to the [Azure Portal](https://portal.azure.com/)

Search for Azure Open AI and fill out the following details

![](https://cdn-images-1.medium.com/max/2000/1*xws3eWBGkR6GfM_axEhVRw.png)

### Step 2: Choose Network

![](https://cdn-images-1.medium.com/max/2000/1*giSqBmyMaFjUqWgYdY01ug.png)

### Step 3: Add Tags

For this exercise tag names are not required. But in a production environment, it should be added as it's a best practice.

![](https://cdn-images-1.medium.com/max/2000/1*fGb9cRt0YUNd3vvVskzETg.png)

### Step 4: Review & Create

![](https://cdn-images-1.medium.com/max/2000/1*xKIonQki46NWUxpmfzI2_g.png)

### Step 5: Move to Open AI Studio

![](https://cdn-images-1.medium.com/max/3646/1*0LQLkFiFC-EiSraIeA7MNQ.png)

On the left side open Models > Select “gpt-35-turbo” > Deploy as highlighted below

The below model list will be populated based on the access provided by the Microsoft team.

### Azure OpenAI includes:

 1. GPT-4 models: Latest generation for natural language and code completions from prompts.

 2. GPT 3.5 models: Generate language and code completions, with turbo versions for chat interactions.

 3. Embedding models: Convert text to numeric vectors, useful for language analytics.

 4. DALL-E models (preview): Generate images from natural language prompts, automatically available without explicit deployment in Azure OpenAI Studio.

![](https://cdn-images-1.medium.com/max/2886/1*bUF748tbzBBpaSxri-4Dsg.png)

### Step 6: Open Playground

![](https://cdn-images-1.medium.com/max/2622/1*i_QvvVmnvnz0_RScCt7ruA.png)

### Step 7: Try Prompts

Input the following prompt in the chat to see if the service is working or not. It may take 5–10 minutes, please be patient.
> # hi can you tell me about viral kohli

Please find below the response to the above prompt.

![](https://cdn-images-1.medium.com/max/2000/1*RUVtCr0GxOkirz4xRlXZrg.png)

### An alternative approach

The whole setup can also be done via the CLI using the following command

    az cognitiveservices account deployment create \
       -g OAIResourceGroup \
       -n MyOpenAIResource \
       --deployment-name MyModel \
       --model-name gpt-35-turbo \
       --model-version "0301"  \
       --model-format OpenAI \
       --sku-name "Standard" \
       --sku-capacity 1

I haven’t tried the CLI approach but just wanted to mention the other alternative.

### Playground Parameters

Play with playground parameters to change the performance of the model.

![](https://cdn-images-1.medium.com/max/2000/1*Jn1xwJdMGYp-lHVfvQ4UVg.png)

### In this module, we learnt

* How to create an Azure Open AI Service.

* How to deploy GPT models.

* How to converse with GPT in the Playground.

* Different approaches to deploying an Open AI service on Azure.

* Playground parameters are available to improve the performance of the model.

### C# Programming🚀

Thank you for being a part of the C# community! Before you leave:

#### If you’ve made it this far, please show your appreciation with a clap and follow the author! 👏️️

Follow us: [X](https://twitter.com/sukhsukhpinder) | [LinkedIn](https://www.linkedin.com/in/sukhpinder-singh/) | [Dev.to](https://dev.to/ssukhpinder) | [Hashnode](https://dotnet.hashnode.dev/) | [Newsletter](https://www.linkedin.com/newsletters/net-programming-7031098498754195456/) | [Tumblr](https://www.tumblr.com/settings/blog/codewithsukh)

Visit our other platforms: [GitHub](https://github.com/ssukhpinder) | [Instagram](https://www.instagram.com/codewithsukh/) | [Tiktok](https://www.tiktok.com/@codewithsukh) | [Quora](https://www.quora.com/profile/Sukhpinder-Singh-4) | [Daily.dev](https://app.daily.dev/devcard)

More content at [C# Programming](https://medium.com/c-sharp-progarmming)

