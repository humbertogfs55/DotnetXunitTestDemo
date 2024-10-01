#!/bin/bash
# Email details
TO_EMAIL=$1
SUBJECT="GitHub Actions Workflow Started"
BODY="The GitHub Actions workflow has started."

# Send email using sendmail
{
  echo "To: ${TO_EMAIL}"
  echo "Subject: ${SUBJECT}"
  echo
  echo "${BODY}"
} | sendmail -t

echo "Email sent to ${TO_EMAIL}"
